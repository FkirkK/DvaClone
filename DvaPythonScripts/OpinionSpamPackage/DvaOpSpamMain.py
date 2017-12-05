import sys
import os
sys.path.append(os.path.join(os.path.dirname(__file__), '..'))

from OpinionSpamPackage import DvaLinearSvm, DvaSvmLinear, DvaPolySvm, DvaRbfSvm, DvaSigmoidSvm, DvaClassifierTree, \
    DvaNaiveBayesClassifier, DvaMLPClassifier, DvaNearestNeighborsClassifier, ParagraphDimensionalizer, \
    DvaAdaBoostClassifier, DvaBaggingClassifier
from OpinionSpamPackage import OpSpamReader
from OpinionSpamPackage import UniGramDimensionalizer
from OpinionSpamPackage import BigramDimensionalizer
from OpinionSpamPackage import BigramPlusDimensionalizer
from OpinionSpamPackage import TrigramDimensionalizer
from OpinionSpamPackage import TrigramPlusDimensionalizer


def DetermineDimensionalizer(dim):
    if dim == "Unigram":
        return UniGramDimensionalizer
    elif dim == "Bigram":
        return BigramDimensionalizer
    elif dim == "BigramPlus":
        return BigramPlusDimensionalizer
    elif dim == "Trigram":
        return TrigramDimensionalizer
    elif dim == "TrigramPlus":
        return TrigramPlusDimensionalizer
    elif dim == "Doc2Vec":
        return ParagraphDimensionalizer
    else:
        return None


def RunAnalysis():
    dim = DetermineDimensionalizer(sys.argv[2])
    if dim is None:
        print("Dimensionalizer not recognized.")
        return None

    # Determine which algorithm to run
    if sys.argv[1] == "LinearSVC":
        classifier = DvaLinearSvm(readReviews, dim)
    elif sys.argv[1] == "SVCLinear":
        classifier = DvaSvmLinear(readReviews, dim)
    elif sys.argv[1] == "SVCPolynomial":
        classifier = DvaPolySvm(readReviews, dim)
    elif sys.argv[1] == "SVCRbf":
        classifier = DvaRbfSvm(readReviews, dim)
    elif sys.argv[1] == "SVCSigmoid":
        classifier = DvaSigmoidSvm(readReviews, dim)
    elif sys.argv[1] == "DecisionTree":
        classifier = DvaClassifierTree(readReviews, dim)
    elif sys.argv[1] == "NaiveBayes":
        classifier = DvaNaiveBayesClassifier(readReviews, dim)
    elif sys.argv[1] == "MultiLayerPerceptron":
        classifier = DvaMLPClassifier(readReviews, dim)
    elif sys.argv[1] == "NearestNeighbors":
        classifier = DvaNearestNeighborsClassifier(readReviews, dim)
    elif sys.argv[1] == "AdaBoost":
        classifier = DvaAdaBoostClassifier(readReviews, dim)
    elif sys.argv[1] == "Bagging":
        classifier = DvaBaggingClassifier(readReviews, dim)

    else:
        print("Classifier not recognized.")
        return None

    # Use dimensionalizer to get results and return these
    classifierResult = classifier.Do5FoldValidation()
    print(classifierResult)


# Read all files
osReader = OpSpamReader()
readReviews = osReader.ReadAllFiles()

# Check if dimensionalizer was specified:
if len(sys.argv) != 3:
    print("Error: Invalid arguments")
else:
    RunAnalysis()
