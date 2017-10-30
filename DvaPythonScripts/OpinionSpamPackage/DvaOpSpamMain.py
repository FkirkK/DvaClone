import sys
import os
sys.path.append(os.path.join(os.path.dirname(__file__), '..'))

from OpinionSpamPackage import DvaLinearSvm, DvaSvmLinear, DvaPolySvm, DvaRbfSvm, DvaSigmoidSvm
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
    else:
        return None

def RunAnalysis():
    dim = DetermineDimensionalizer(sys.argv[2])
    if dim is None:
        print("Dimensionalizer not recognized.")
        return None

    # Determine which algorithm to run
    if sys.argv[1] == "LinearSVC":
        DvaSVM = DvaLinearSvm(readReviews, DetermineDimensionalizer(sys.argv[2]))
    elif sys.argv[1] == "SVCLinear":
        DvaSVM = DvaSvmLinear(readReviews, DetermineDimensionalizer(sys.argv[2]))
    elif sys.argv[1] == "SVCPolynomial":
        DvaSVM = DvaPolySvm(readReviews, DetermineDimensionalizer(sys.argv[2]))
    elif sys.argv[1] == "SVCRbf":
        DvaSVM = DvaRbfSvm(readReviews, DetermineDimensionalizer(sys.argv[2]))
    elif sys.argv[1] == "SVCSigmoid":
        DvaSVM = DvaSigmoidSvm(readReviews, DetermineDimensionalizer(sys.argv[2]))
    else:
        print("Classifier not recognized.")
        return None

    # Use dimensionalizer to get results and return these
    classifierResult = DvaSVM.Do5FoldValidation()
    print(classifierResult)


# Read all files
osReader = OpSpamReader()
readReviews = osReader.ReadAllFiles()

# Check if dimensionalizer was specified:
if len(sys.argv) != 3:
    print("Error: Invalid arguments")
else:
    RunAnalysis()
