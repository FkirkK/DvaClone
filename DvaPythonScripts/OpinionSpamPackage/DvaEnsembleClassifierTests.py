from unittest import TestCase
from OpinionSpamPackage import DvaAdaBoostClassifier, DvaBaggingClassifier, OpSpamReader, ClassifierResult


class DvaAdaBoostClassifierTests(TestCase):

    def setUp(self):
        self.osReader = OpSpamReader()
        self.allReviews = self.osReader.ReadAllFiles()
        self.adaBoostClassifier = DvaAdaBoostClassifier(reviewList=self.allReviews)

    def test_is_model_learned(self):
        # Arrange

        # Act
        self.adaBoostClassifier.LearnModelForAllReviews()

        # Assert
        self.assertTrue(self.adaBoostClassifier.model is not None)

    def test_returns_valid_classifierResult(self):
        # Arrange

        # Act
        classifierResult = self.adaBoostClassifier.Do5FoldValidation()

        # Assert
        self.assertTrue(type(classifierResult) is ClassifierResult)
        self.assertTrue(0 <= classifierResult.precision <= 1)

    def test_returns_expected_result_on_unigram(self):
        # Arrange
        expectedResult = 0.7975

        # Act
        classifierResult = self.adaBoostClassifier.Do5FoldValidation()

        # Assert
        self.assertEqual(expectedResult, classifierResult.precision)

from unittest import TestCase
from OpinionSpamPackage import DvaNaiveBayesClassifier, OpSpamReader, ClassifierResult


class DvaBaggingClassifierTests(TestCase):

    def setUp(self):
        self.osReader = OpSpamReader()
        self.allReviews = self.osReader.ReadAllFiles()
        self.baggingClassifier = DvaBaggingClassifier(reviewList=self.allReviews)

    def test_is_model_learned(self):
        # Arrange

        # Act
        self.baggingClassifier.LearnModelForAllReviews()

        # Assert
        self.assertTrue(self.baggingClassifier.model is not None)

    def test_returns_valid_classifierResult(self):
        # Arrange

        # Act
        classifierResult = self.baggingClassifier.Do5FoldValidation()

        # Assert
        self.assertTrue(type(classifierResult) is ClassifierResult)
        self.assertTrue(0 <= classifierResult.precision <= 1)

    def test_returns_expected_result_on_unigram(self):
        # Arrange
        expectedResultLower = 0.69

        # Act
        classifierResult = self.baggingClassifier.Do5FoldValidation()

        # Assert
        self.assertTrue(expectedResultLower <= classifierResult.precision <= 1)