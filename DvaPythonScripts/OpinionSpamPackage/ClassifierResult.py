

class ClassifierResult:

    def __init__(self, fold, precision, fakePositives, fakeNegatives, reviewList, pBest=None, pWorst=None, fpBest=None, fpWorst=None, fnBest=None, fnWorst=None):
        self.fold = fold
        self.precision = precision
        self.fakePositives = fakePositives
        self.fakeNegatives = fakeNegatives
        self.reviews = reviewList

        self.precisionBestFold = self.fold if pBest is None else pBest
        self.precisionWorstFold = self.fold if pWorst is None else pWorst
        self.fakePositivesBestFold = self.fold if fpBest is None else fpBest
        self.fakePositivesWorstFold = self.fold if fpWorst is None else fpWorst
        self.fakeNegativesBestFold = self.fold if fnBest is None else fnBest
        self.fakeNegativesWorstFold = self.fold if fnWorst is None else fnWorst

        #Todo: Include list of all reviews, their actual value, and their predicted value

    def AggregateResults(resultList):
        fold = 0
        numberOfResultsToAggregate = len(resultList)
        precision = 0
        fakePositives = 0
        fakeNegatives = 0
        reviews = []

        precisionBestFold = 0
        precisionOfBestFold = 0
        precisionWorstFold = 0
        precisionOfWorstFold = 100
        fakePositivesBestFold = 0
        fakePositivesOfBestFold = 100
        fakePositivesWorstFold = 0
        fakePositivesOfWorstFold = 0
        fakeNegativesBestFold = 0
        fakeNegativesOfBestFold = 100
        fakeNegativesWorstFold = 0
        fakeNegativesOfWorstFold = 0

        # First calculate scoreSums
        for result in resultList:
            precision += result.precision / numberOfResultsToAggregate
            fakePositives += result.fakePositives / numberOfResultsToAggregate
            fakeNegatives += result.fakeNegatives / numberOfResultsToAggregate
            reviews.extend(result.reviews)
            if precisionOfBestFold < result.precision:
                precisionBestFold = result.fold
                precisionOfBestFold = result.precision
            if precisionOfWorstFold > result.precision:
                precisionWorstFold = result.fold
                precisionOfWorstFold = result.precision
            if fakePositivesOfBestFold > result.fakePositives:
                fakePositivesBestFold = result.fold
                fakePositivesOfBestFold = result.fakePositives
            if fakePositivesOfWorstFold < result.fakePositives:
                fakePositivesWorstFold = result.fold
                fakePositivesOfWorstFold = result.fakePositives
            if fakeNegativesOfBestFold > result.fakeNegatives:
                fakeNegativesBestFold = result.fold
                fakeNegativesOfBestFold = result.fakeNegatives
            if fakeNegativesOfWorstFold < result.fakeNegatives:
                fakeNegativesWorstFold = result.fold
                fakeNegativesOfWorstFold = result.fakeNegatives

        return ClassifierResult(fold, precision, fakePositives, fakeNegatives, reviews, precisionBestFold,
                                precisionWorstFold, fakePositivesBestFold, fakePositivesWorstFold,
                                fakeNegativesBestFold, fakeNegativesWorstFold)

    def __str__(self):
        returnString = ""
        returnString += str(self.precision) + ", "
        returnString += str(self.precisionBestFold) + ", "
        returnString += str(self.precisionWorstFold) + ", "
        returnString += str(self.fakePositives) + ", "
        returnString += str(self.fakePositivesBestFold) + ", "
        returnString += str(self.fakePositivesWorstFold) + ", "
        returnString += str(self.fakeNegatives) + ", "
        returnString += str(self.fakeNegativesBestFold) + ", "
        returnString += str(self.fakeNegativesWorstFold) + ", "
        for review in self.reviews:
            returnString += review[0] + ", " + ("1" if review[1] else "0") + ", " + ("1" if review[2] else "0") + ", "
        returnString = returnString[:-2]
        return returnString


