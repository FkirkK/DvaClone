from OpinionSpamPackage import DvaGeneralClassifier
from OpinionSpamPackage import BigramPlusDimensionalizer
from sklearn import svm


class DvaLinearSvm(DvaGeneralClassifier):
    def __init__(self, reviewList, dimensionalizerClass=BigramPlusDimensionalizer):
        super().__init__(reviewList=reviewList, dimensionalizerClass=dimensionalizerClass, classifier=svm.LinearSVC())


class DvaPolySvm(DvaGeneralClassifier):
    def __init__(self, reviewList, dimensionalizerClass=BigramPlusDimensionalizer):
        super().__init__(reviewList=reviewList, dimensionalizerClass=dimensionalizerClass, classifier=svm.SVC(kernel="polynomial"))


class DvaRbfSvm(DvaGeneralClassifier):
    def __init__(self, reviewList, dimensionalizerClass=BigramPlusDimensionalizer):
        super().__init__(reviewList=reviewList, dimensionalizerClass=dimensionalizerClass, classifier=svm.SVC(kernel="rbf"))


class DvaSigmoidSvm(DvaGeneralClassifier):
    def __init__(self, reviewList, dimensionalizerClass=BigramPlusDimensionalizer):
        super().__init__(reviewList=reviewList, dimensionalizerClass=dimensionalizerClass, classifier=svm.SVC(kernel="sigmoid"))


class DvaSvmLinear(DvaGeneralClassifier):
    def __init__(self, reviewList, dimensionalizerClass=BigramPlusDimensionalizer):
        super().__init__(reviewList=reviewList, dimensionalizerClass=dimensionalizerClass,
                         classifier=svm.SVC(kernel="linear"))
