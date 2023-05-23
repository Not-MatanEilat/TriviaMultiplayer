import requests
import json
import sqlite3

DB_PATH = "TrivyaLidanMatan\\TrivyaLidanMatan\\Trivia.db"


def main():
    # get answers from API
    answer = requests.get("https://opentdb.com/api.php?amount=10&category=15&difficulty=medium&type=multiple")

    # connect the db and make a cursor object (object used to execute)
    connect = sqlite3.connect(DB_PATH)
    cursor = connect.cursor()

    # make the answer into a json
    answer_json = json.loads(answer.text)

    # iterate all questions and put each one of the inside of the data base
    for result in answer_json["results"]:
        # get the json's data
        question = result["question"]

        correct_answer = result["correct_answer"]
        incorrect_answers = result["incorrect_answers"]

        # the line to execute
        execute_line = f'INSERT INTO questions VALUES ("{question}", "{correct_answer}", "{incorrect_answers[0]}", "{incorrect_answers[1]}", "{incorrect_answers[2]}")'

        # execute and then commit
        cursor.execute(execute_line)
        connect.commit()

    # after, close the database
    connect.close()


if __name__ == "__main__":
    main()
