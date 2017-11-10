from collections import namedtuple

import numpy
from gensim.models import doc2vec

from OpinionSpamPackage import GeneralDimensionalizer


class ParagraphDimensionalizer(GeneralDimensionalizer):

    def __init__(self, reviewList):
        super().__init__(reviewList, self.__ConstructFeatureSetInRange)
        self.__vectorSize = 100
        self.model = doc2vec.Doc2Vec(self.__ConvertReviewsToDocToVecDocuments(self.reviewList), size=self.__vectorSize, window=300, min_count=1, workers=4)

    def __ConvertReviewsToDocToVecDocuments(self, reviewList):
        documentList = []
        analyzedDocument = namedtuple('AnalyzedDocument', 'words tags')  # Named tuple with typename and fieldnames

        tag = 0
        myTags = [tag]  # Customizable tag
        for review in reviewList:
            content = self.RemoveAllNewlines(review.content.split())
            documentList.append(analyzedDocument(content, myTags))
            myTags[0] = tag + 1

        return documentList

    def __ConstructFeatureSetInRange(self, reviewIndexList):  # rangeMin is zero indexed
        matrix = numpy.zeros(shape=(len(reviewIndexList), self.__vectorSize))

        i = 0
        for index in reviewIndexList:
            vector = self.model.docvecs[index]
            matrix[i] = vector
            i += 1

        return matrix


