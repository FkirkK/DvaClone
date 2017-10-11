


class Dimensionalizer:

    def __init__(self):
        self.dimensionSet = set()

    def DimensionalizeReviewBigramPlus(self, review):
        splitContent = review.content.split(" ")
        splitContent = self.__RemoveAllNewlines(splitContent)
        for i in range(0, len(splitContent)-1):
            self.dimensionSet.add(splitContent[i])
            self.dimensionSet.add(splitContent[i] + " " + splitContent[i+1])
        self.dimensionSet.add(splitContent[len(splitContent)-1])  # Done to get last element not caught in loop

    def __RemoveAllNewlines(self, contentList):
        returnList = []
        for i in range(0, len(contentList)):
            if contentList[i] != "\n" and contentList[i] != "":
                returnList.append(contentList[i])
        return returnList
