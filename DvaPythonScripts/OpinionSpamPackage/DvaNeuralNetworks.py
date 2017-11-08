from OpinionSpamPackage import DvaGeneralClassifier, UniGramDimensionalizer
from sklearn.neural_network import MLPClassifier


class DvaMLPClassifier(DvaGeneralClassifier):

    def __init__(self, reviewList, dimensionalizerClass=UniGramDimensionalizer):
        super().__init__(reviewList=reviewList, dimensionalizerClass=dimensionalizerClass, classifier=MLPClassifier())

