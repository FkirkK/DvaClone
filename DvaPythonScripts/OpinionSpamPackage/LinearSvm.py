import sys
import os
sys.path.append(os.path.join(os.path.dirname(__file__), '..'))

from OpinionSpamPackage import DvaLinearSvm
from OpinionSpamPackage import OpSpamReader
from OpinionSpamPackage import UniGramDimensionalizer
from OpinionSpamPackage import BigramDimensionalizer
from OpinionSpamPackage import BigramPlusDimensionalizer
from OpinionSpamPackage import TrigramDimensionalizer
from OpinionSpamPackage import TrigramPlusDimensionalizer


# Read all files
osReader = OpSpamReader()
readReviews = osReader.ReadAllFiles()

# Check if dimensionalizer was specified:
if len(sys.argv) > 1:
    if sys.argv[1] == "Unigram":
        DvaSVM = DvaLinearSvm(readReviews, UniGramDimensionalizer)
    elif sys.argv[1] == "Bigram":
        DvaSVM = DvaLinearSvm(readReviews, BigramDimensionalizer)
    elif sys.argv[1] == "BigramPlus":
        DvaSVM = DvaLinearSvm(readReviews, BigramPlusDimensionalizer)
    elif sys.argv[1] == "Trigram":
        DvaSVM = DvaLinearSvm(readReviews, TrigramDimensionalizer)
    elif sys.argv[1] == "TrigramPlus":
        DvaSVM = DvaLinearSvm(readReviews, TrigramPlusDimensionalizer)
    else:
        DvaSVM = DvaLinearSvm(readReviews)  # Default dimensionalizer
else:
    DvaSVM = DvaLinearSvm(readReviews)  # This defaults to BigramPlusDimensionalizer

# Use dimensionalizer to get results and return these
classifierResult = DvaSVM.Do5FoldValidation()
print(classifierResult)
