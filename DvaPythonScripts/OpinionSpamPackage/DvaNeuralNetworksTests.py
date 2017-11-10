from unittest import TestCase
from OpinionSpamPackage import DvaMLPClassifier, OpSpamReader, ClassifierResult


class DvaMLPClassifierTests(TestCase):

    def setUp(self):
        self.osReader = OpSpamReader()
        self.allReviews = self.osReader.ReadAllFiles()
        self.mLPClassifier = DvaMLPClassifier(reviewList=self.allReviews)

    def test_is_model_learned(self):
        # Arrange

        # Act
        self.mLPClassifier.LearnModelForAllReviews()

        # Assert
        self.assertTrue(self.mLPClassifier.model is not None)

    def test_returns_valid_classifierResult(self):
        # Arrange

        # Act
        classifierResult = self.mLPClassifier.Do5FoldValidation()

        # Assert
        self.assertTrue(type(classifierResult) is ClassifierResult)
        self.assertTrue(0 <= classifierResult.precision <= 1)

