from unittest import TestCase
from OpinionSpamPackage import ClassifierResult


class ClassifierResultTests(TestCase):

    def setUp(self):
        self.resultList = []
        self.resultList.append(ClassifierResult(trueTruthful=130, falseTruthful=25, trueDeceitful=140, falseDeceitful=25, reviewList=[]))
        self.resultList.append(ClassifierResult(trueTruthful=160, falseTruthful=0, trueDeceitful=160, falseDeceitful=0, reviewList=[]))
        self.resultList.append(ClassifierResult(trueTruthful=150, falseTruthful=20, trueDeceitful=140, falseDeceitful=10, reviewList=[]))
        self.resultList.append(ClassifierResult(trueTruthful=155, falseTruthful=10, trueDeceitful=155, falseDeceitful=0, reviewList=[]))
        self.resultList.append(ClassifierResult(trueTruthful=110, falseTruthful=80, trueDeceitful=120, falseDeceitful=10, reviewList=[]))
        self.aggregatedResult = ClassifierResult.AggregateResults(self.resultList)

    def test_aggregate_returns_new_classifierResult(self):
        # Arrange
        expectedValue = True

        # Act

        # Assert
        self.assertEqual(type(self.aggregatedResult) is ClassifierResult, expectedValue)

    def test_aggregates_trueTruthful_correctly(self):
        # Arrange
        expectedCount = 705

        # Act

        # Assert
        self.assertEqual(self.aggregatedResult.trueTruthful, expectedCount)

    def test_aggregates_falseTruthful_correctly(self):
        # Arrange
        expectedCount = 135

        # Act

        # Assert
        self.assertEqual(self.aggregatedResult.falseTruthful, expectedCount)

    def test_aggregates_trueDeceitful_correctly(self):
        # Arrange
        expectedCount = 715

        # Act

        # Assert
        self.assertEqual(self.aggregatedResult.trueDeceitful, expectedCount)

    def test_aggregates_falseDeceitful_correctly(self):
        # Arrange
        expectedCount = 45

        # Act

        # Assert
        self.assertEqual(self.aggregatedResult.falseDeceitful, expectedCount)


    def test_print_has_correct_amount_of_fields(self):
        # Arrange
        expectedFieldCount = 4

        # Act
        string = self.aggregatedResult.__str__()
        actualFieldCount = len(string.split(","))

        # Assert
        self.assertEqual(expectedFieldCount, actualFieldCount)

    def test_print_has_correct_amount_of_fields_with_reviews(self):
        # Arrange
        expectedFieldCount = 10
        self.aggregatedResult.reviews.append(("t_hilton_1.txt", True, False))
        self.aggregatedResult.reviews.append(("t_hilton_5.txt", True, True))

        # Act
        string = self.aggregatedResult.__str__()
        actualFieldCount = len(string.split(","))

        # Assert
        self.assertEqual(expectedFieldCount, actualFieldCount)

    def test_prints_reviews_correctly(self):
        # Arrange
        expectedField4String = " t_hilton_1.txt"
        expectedField5String = " 1"
        expectedField6String = " 0"
        expectedField7String = " t_hilton_5.txt"
        expectedField8String = " 1"
        expectedField9String = " 1"
        self.aggregatedResult.reviews.append(("t_hilton_1.txt", True, False))
        self.aggregatedResult.reviews.append(("t_hilton_5.txt", True, True))

        # Act
        string = self.aggregatedResult.__str__()
        splitFields = string.split(",")

        # Assert
        self.assertEqual(expectedField4String, splitFields[4])
        self.assertEqual(expectedField5String, splitFields[5])
        self.assertEqual(expectedField6String, splitFields[6])
        self.assertEqual(expectedField7String, splitFields[7])
        self.assertEqual(expectedField8String, splitFields[8])
        self.assertEqual(expectedField9String, splitFields[9])

