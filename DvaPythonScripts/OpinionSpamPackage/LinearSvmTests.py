from unittest import TestCase
from OpinionSpamPackage import OpSpamReader
from OpinionSpamPackage import DvaLinearSvm
from sklearn import svm
import numpy


class LinearSvmTests(TestCase):

    def setUp(self):
        self.osReader = OpSpamReader()
        self.allReviews = self.osReader.ReadAllFiles()
        self.dvaLinearSVM = DvaLinearSvm(self.allReviews)

    def test_instantiates_with_right_amount_of_reviews(self):
        # Arrange
        expectedAmount = 1600

        # Act
        # Handled by setUp()

        # Assert
        self.assertEqual(len(self.dvaLinearSVM.reviewList), expectedAmount)

    def test_is_a_model_learned(self):
        # Arrange
        expectedValue = True

        # Act
        self.dvaLinearSVM.LearnModel()

        # Assert
        self.assertEqual(type(self.dvaLinearSVM.model) is svm.LinearSVC, expectedValue)

    def test_can_model_predict_own_member_correctly(self):
        # Arrange
        expectedValue = True

        # Act
        self.dvaLinearSVM.LearnModel()
        vectorToPredict = numpy.zeros(shape=(1, self.dvaLinearSVM.dimensionalizer.numberOfNGramsInDict))
        setToPopulateVector = self.dvaLinearSVM.dimensionalizer.GetBigramsPlusFromReview(self.allReviews[0])
        for bigram in setToPopulateVector:
            indexInVector = self.dvaLinearSVM.dimensionalizer.mappingDictionary[bigram]
            vectorToPredict[0][indexInVector] = 1
        prediction = self.dvaLinearSVM.model.predict(vectorToPredict)

        # Assert
        self.assertEqual(prediction, expectedValue)
