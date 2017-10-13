import os.path
from OpinionSpamPackage import Review

class OpSpamReader:

    def __init__(self, opSpamFolderPath=os.path.join(os.path.dirname(os.path.dirname(os.getcwd())), "op_spam_v1.4")):
        self.rootPath = opSpamFolderPath

    def ReadSingleFile(self, fullPath, isTruthful, isPositive, fold):

        with open(fullPath, 'r') as fileHandle:
            content = fileHandle.read()
            title = os.path.split(fullPath)

        return Review(isTruthful, isPositive, title[1], content, fold)

    def ReadAllFiles(self):
        reviewList = []

        reviewList.extend(self.ReadFolds(os.path.join("positive_polarity", "truthful_from_TripAdvisor"), True, True, 5))
        reviewList.extend(self.ReadFolds(os.path.join("positive_polarity", "deceptive_from_MTurk"), False, True, 5))
        reviewList.extend(self.ReadFolds(os.path.join("negative_polarity", "truthful_from_Web"), True, False, 5))
        reviewList.extend(self.ReadFolds(os.path.join("negative_polarity", "deceptive_from_MTurk"), False, False, 5))

        return reviewList

    def ReadFolds(self, appendingPath, isTruthful, isPositive, nrOfFolds):
        fullPath = os.path.join(self.rootPath, appendingPath)
        returnList = []

        for i in range(1, nrOfFolds+1):
            currentFoldPath = os.path.join(fullPath, "fold{nr}".format(nr=i))
            # The below expression discovers all files in the fold path
            files = [f for f in os.listdir(currentFoldPath) if os.path.isfile(os.path.join(currentFoldPath, f))]

            for file in files:
                returnList.append(self.ReadSingleFile(os.path.join(currentFoldPath, file), isTruthful, isPositive, i))
        return returnList

