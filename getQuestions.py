from html import unescape
import requests
import json
import sqlite3

DB_PATH = "TrivyaLidanMatan\\TrivyaLidanMatan\\Trivia.db"

def custom_unescape(string: str) -> str:
    """
    Custom unescape for the html
    :param string: the string to unescape
    :return: the unescaped string
    """
    # unescape the string and replace the quotes
    string = unescape(string)
    string = string.replace('"', '""')
    return string

def custom_decoder(dct: dict) -> dict:
    """
    Custom decoder for the json
    :param dct: the dictionary to decode
    :return: the decoded dictionary
    """
    # if the key is question, unescape it
    if "question" in dct:
        dct["question"] = custom_unescape(dct["question"])
        dct["correct_answer"] = custom_unescape(dct["correct_answer"])
        dct["incorrect_answers"] = [custom_unescape(answer) for answer in dct["incorrect_answers"]]
    return dct

def main():
    # get answers from API
    answer = requests.get(f'https://opentdb.com/api.php?amount=50&type=multiple')

    # connect the db and make a cursor object (object used to execute)
    connect = sqlite3.connect(DB_PATH)
    cursor = connect.cursor()

    response = answer.text
    # response = response.replace('"', '""')

    # make the answer into a json
    answer_json = json.loads(response, object_hook=custom_decoder)


    # iterate all questions and put each one of the inside of the data base
    for result in answer_json["results"]:
        # get the json's data
        question = result["question"]

        # quotes are being passed as "quot;" in the question so we replace those
        
        correct_answer = result["correct_answer"]
        incorrect_answers = result["incorrect_answers"]

        # the line to execute
        execute_line = f'INSERT INTO questions VALUES ("{question}", "{correct_answer}", "{incorrect_answers[0]}", "{incorrect_answers[1]}", "{incorrect_answers[2]}")'

        # execute and then commit
        try:
            cursor.execute(execute_line)
            connect.commit()
        except sqlite3.IntegrityError:
            print("Question already exists " + question)

    # after, close the database
    connect.close()
    print("Done!")


if __name__ == "__main__":
    main()
