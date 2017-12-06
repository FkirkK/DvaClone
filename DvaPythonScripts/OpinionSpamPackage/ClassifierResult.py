

class ClassifierResult:

    def __init__(self, trueTruthful, falseTruthful, trueDeceitful, falseDeceitful, reviewList):
        self.trueTruthful = trueTruthful
        self.falseTruthful = falseTruthful
        self.trueDeceitful = trueDeceitful
        self.falseDeceitful = falseDeceitful
        self.reviews = reviewList

    def AggregateResults(resultList):
        trueTruthful = 0
        falseTruthful = 0
        trueDeceitful = 0
        falseDeceitful = 0
        reviews = []

        # First calculate scoreSums
        for result in resultList:
            trueTruthful += result.trueTruthful
            falseTruthful += result.falseTruthful
            trueDeceitful += result.trueDeceitful
            falseDeceitful += result.falseDeceitful
            reviews.extend(result.reviews)

        return ClassifierResult(trueTruthful=trueTruthful, falseTruthful=falseTruthful, trueDeceitful=trueDeceitful,
                                falseDeceitful=falseDeceitful, reviewList=reviews)

    def __str__(self):
        returnString = ""
        returnString += str(self.trueTruthful) + ", "
        returnString += str(self.falseTruthful) + ", "
        returnString += str(self.trueDeceitful) + ", "
        returnString += str(self.falseDeceitful) + ", "
        for review in self.reviews:
            returnString += review[0] + ", " + ("1" if review[1] else "0") + ", " + ("1" if review[2] else "0") + ", "
        returnString = returnString[:-2]
        return returnString


