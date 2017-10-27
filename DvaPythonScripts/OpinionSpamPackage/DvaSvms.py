from OpinionSpamPackage import DvaGeneralSvm
from OpinionSpamPackage import BigramPlusDimensionalizer
from sklearn import svm


class DvaLinearSvm(DvaGeneralSvm):
    def __init__(self, reviewList, dimensionalizerClass=BigramPlusDimensionalizer):
        super().__init__(reviewList=reviewList, dimensionalizerClass=dimensionalizerClass, classifier=svm.LinearSVC())


class DvaPolySvm(DvaGeneralSvm):
    def __init__(self, reviewList, dimensionalizerClass=BigramPlusDimensionalizer):
        super().__init__(reviewList=reviewList, dimensionalizerClass=dimensionalizerClass, classifier=svm.SVC(kernel="polynomial"))


class DvaRbfSvm(DvaGeneralSvm):
    def __init__(self, reviewList, dimensionalizerClass=BigramPlusDimensionalizer):
        super().__init__(reviewList=reviewList, dimensionalizerClass=dimensionalizerClass, classifier=svm.SVC(kernel="rbf"))


class DvaSigmoidSvm(DvaGeneralSvm):
    def __init__(self, reviewList, dimensionalizerClass=BigramPlusDimensionalizer):
        super().__init__(reviewList=reviewList, dimensionalizerClass=dimensionalizerClass, classifier=svm.SVC(kernel="sigmoid"))
