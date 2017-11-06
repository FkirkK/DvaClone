from OpinionSpamPackage import GeneralDimensionalizer


class UniGramDimensionalizer(GeneralDimensionalizer):

    def __init__(self):
        super().__init__(self.GetUnigramsFromReview)

    def GetUnigramsFromReview(self, review):
        returnSet = set()
        splitContent = review.content.split(" ")
        splitContent = super().RemoveAllNewlines(splitContent)

        for i in range(0, len(splitContent)):
            returnSet.add(splitContent[i])

        return returnSet


class BigramDimensionalizer(GeneralDimensionalizer):

    def __init__(self, reviewList):
        super().__init__(self.GetBigramsFromReview, reviewList)

    def GetBigramsFromReview(self, review):
        returnSet = set()
        splitContent = review.content.split(" ")
        splitContent = super().RemoveAllNewlines(splitContent)

        for i in range(0, len(splitContent) - 1):
            returnSet.add(splitContent[i] + " " + splitContent[i + 1])

        return returnSet


class BigramPlusDimensionalizer(GeneralDimensionalizer):

    def __init__(self, revieList):
        super().__init__(self.GetBigramsPlusFromReview, reviewList=revieList)

    def GetBigramsPlusFromReview(self, review):
        returnSet = set()
        splitContent = review.content.split(" ")
        splitContent = super().RemoveAllNewlines(splitContent)

        for i in range(0, len(splitContent) - 1):
            returnSet.add(splitContent[i])
            returnSet.add(splitContent[i] + " " + splitContent[i + 1])
        returnSet.add(splitContent[len(splitContent) - 1])  # Done to get last element not caught in loop

        return returnSet


class TrigramDimensionalizer(GeneralDimensionalizer):

    def __init__(self, reviewList):
        super().__init__(self.GetTrigramsFromReview, reviewList)

    def GetTrigramsFromReview(self, review):
        returnSet = set()
        splitContent = review.content.split(" ")
        splitContent = super().RemoveAllNewlines(splitContent)

        for i in range(0, len(splitContent) - 2):
            returnSet.add(splitContent[i] + " " + splitContent[i+1] + " " + splitContent[i+2])

        return returnSet


class TrigramPlusDimensionalizer(GeneralDimensionalizer):

    def __init__(self, reviewList):
        super().__init__(self.GetTrigramsPlusFromReview, reviewList)

    def GetTrigramsPlusFromReview(self, review):
        returnSet = set()
        splitContent = review.content.split(" ")
        splitContent = super().RemoveAllNewlines(splitContent)

        for i in range(0, len(splitContent) - 2):
            returnSet.add(splitContent[i] + " " + splitContent[i+1] + " " + splitContent[i+2])
            returnSet.add(splitContent[i] + " " + splitContent[i+1])
            returnSet.add(splitContent[i])

        returnSet.add(splitContent[len(splitContent) - 1])
        returnSet.add(splitContent[len(splitContent) - 2])  # Picking up final grams not included in loop
        returnSet.add(splitContent[len(splitContent) - 2] + " " + splitContent[len(splitContent) - 1])

        return returnSet
