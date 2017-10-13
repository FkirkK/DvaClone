import os.path
import sys

sys.path.append(os.path.join(os.path.dirname(__file__), '..'))

from OpinionSpamPackage import DvaLinearSvm
from OpinionSpamPackage import OpSpamReader



osReader = OpSpamReader()
readReviews = osReader.ReadAllFiles()

DvaSVM = DvaLinearSvm(readReviews)
classifierResult = DvaSVM.Do5FoldValidation()

print(classifierResult)
