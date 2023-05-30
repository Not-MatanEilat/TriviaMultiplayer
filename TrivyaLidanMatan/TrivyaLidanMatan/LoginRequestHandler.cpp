#include "LoginRequestHandler.h"

#include "JsonRequestPacketDeserializer.h"
#include "JsonResponsePacketSerializer.h"

/**
 * \brief Constructor for the LoginRequestHandler
 * \param handlerFactory The factory for the class
 */
LoginRequestHandler::LoginRequestHandler(RequestHandlerFactory& handlerFactory) : m_handlerFactory(handlerFactory)
{

}

/**
 * \brief checks if the request is relevant
 * \return true if request is relevant
 */
bool LoginRequestHandler::isRequestRelevant(RequestInfo info)
{
	return info.requestId == LOGIN_CODE || info.requestId == SIGNUP_CODE;
}

/**
 * \brief handles the request
 * \return request result
 */
RequestResult LoginRequestHandler::handleRequest(RequestInfo info)
{
	RequestResult result;
	result.newHandler = nullptr;
	if (info.requestId == LOGIN_CODE)
	{
		TRACE("got login request");
		result = login(info);
	}
	else if (info.requestId == SIGNUP_CODE)
	{
		TRACE("got signup request");
		result = signup(info);
	}
	return result;
}

/**
 * \brief handles client disconnecting
 */
void LoginRequestHandler::handleDisconnect()
{
}


/**
 * \brief The function will take a login request and deserialize it to a login request object
 * \param info the info of the request
 * \return the request login result
 */
RequestResult LoginRequestHandler::login(RequestInfo const &info)
{
	LoginRequest const loginRequest = JsonRequestPacketDeserializer::deserializeLoginRequest(info.buffer);

	RequestResult result;
	LoginResponse response;
	TRACE("Trying to login with username: " << loginRequest.username << " password: " << loginRequest.password);
	try
	{
		// login, if failed (username or password is wrong) will return a response with a failed status
		m_handlerFactory.getLoginManager().login(loginRequest.username, loginRequest.password);
		response.status = SUCCESS;
		Buffer const buffer = JsonResponsePacketSerializer::serializeResponse(response);
		result.newHandler = m_handlerFactory.createMenuRequestHandler(m_handlerFactory.getLoginManager().getLoggedUser(loginRequest.username));;
		result.response = buffer;
		TRACE("Login success");
	}
	catch (std::exception const &e)
	{
		ErrorResponse error;
		error.message = "Something went wrong: " + std::string(e.what());
		result.response = JsonResponsePacketSerializer::serializeResponse(error);
		result.newHandler = this;
		TRACE("Login failed " << e.what());
	}

	return result;
}

/**
 * \brief The function will take a signup request and deserialize it to a signup request object
 * \param info the info of the request
 * \return the request signup result
 */
RequestResult LoginRequestHandler::signup(RequestInfo const &info)
{
	SignupRequest const signupRequest = JsonRequestPacketDeserializer::deserializeSignupRequest(info.buffer);

	RequestResult result;
	SignupResponse response;
	TRACE("Trying to signup with username: " << signupRequest.username << " password: " << signupRequest.password << " email: " << signupRequest.email);
	try
	{
		// signup, if failed (something went wrong there) will return a response with a failed status
		m_handlerFactory.getLoginManager().signUp(signupRequest.username, signupRequest.password, signupRequest.email);
		response.status = SUCCESS;
		Buffer const buffer = JsonResponsePacketSerializer::serializeResponse(response);
		result.newHandler = m_handlerFactory.createMenuRequestHandler(m_handlerFactory.getLoginManager().getLoggedUser(signupRequest.username));;
		result.response = buffer;
		TRACE("Signup success");
	}
	catch (std::exception const& e)
	{
		ErrorResponse error;
		error.message = "Something went wrong: " + std::string(e.what());
		result.response = JsonResponsePacketSerializer::serializeResponse(error);
		result.newHandler = this;
		TRACE("Signup failed " << e.what());
	}

	return result;
}