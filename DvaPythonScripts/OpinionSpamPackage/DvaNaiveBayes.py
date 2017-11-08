from OpinionSpamPackage import DvaGeneralClassifier, UniGramDimensionalizer
from sklearn.naive_bayes import GaussianNB


class DvaNaiveBayesClassifier(DvaGeneralClassifier):

    def __init__(self, reviewList, dimensionalizerClass=UniGramDimensionalizer):
        super().__init__(reviewList=reviewList, dimensionalizerClass=dimensionalizerClass, classifier=GaussianNB())
