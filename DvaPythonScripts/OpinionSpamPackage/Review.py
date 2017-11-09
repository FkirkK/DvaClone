import re


class Review:

    def __init__(self, isTruthful, isPositive, title, content, fold):
        self.isTruthful = isTruthful
        self.isPositive = isPositive
        self.title = title
        self.content = content.lower()
        self.content = re.sub(r'[.,?!:;_()]*', "", self.content)
        self.fold = fold
