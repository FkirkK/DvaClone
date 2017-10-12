import os
from OpinionSpamPackage import DvaLinearSvm
from OpinionSpamPackage import OpSpamReader

osReader = OpSpamReader(opSpamFolderPath=os.path.dirname(os.path.dirname(os.getcwd())) + "\\op_spam_v1.4")
readReviews = osReader.ReadAllFiles()

DvaSVM = DvaLinearSvm(readReviews)
classifierResult = DvaSVM.Do5FoldValidation()

print(classifierResult)
