


class Dimensionalizer:

    def __init__(self):
        self.dimensionSet = set()

    def DimensionalizeReview(self, review):
        splitContent = review.content.split(" ")
        for i in range(0, len(splitContent)-1):
            self.dimensionSet.add(splitContent[i])
            self.dimensionSet.add(splitContent[i] + " " + splitContent[i+1])
        self.dimensionSet.add(splitContent[len(splitContent)-1])  # Done to get last element not caught in loop
