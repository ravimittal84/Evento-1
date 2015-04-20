
var Request = function (totalItems, currentPage, pageSize, maxSize) {
    self = this;
    self.TotalItems = totalItems ? totalItems : 0;
    self.CurrentPage = currentPage ? currentPage : 1;
    self.MaxSize = maxSize ? maxSize : 5;
    self.PageSize = pageSize ? pageSize : 10;
    self.GroupBy = '';
    self.SortDirection = 'Ascending';
    self.SortField = 'ProjectName';
    self.Criteria = null;
    self.NumberOfPages = self.TotalItems == 0 ? 0 : parseInt(self.TotalItems) / parseInt(self.PageSize) + ((self.TotalItems % self.PageSize > 0) ? 1 : 0);

    // Setter
    self.set = function (params) {
        self.TotalItems = params.TotalItems ? params.TotalItems : 0;
        self.CurrentPage = params.CurrentPage ? params.CurrentPage : 1;
        self.MaxSize = params.maxSize ? params.maxSize : 5;
        self.PageSize = params.PageSize ? params.PageSize : 10;
        self.NumberOfPages = self.TotalItems == 0 ? 0 : self.TotalItems / self.PageSize + ((self.TotalItems % self.PageSize > 0) ? 1 : 0);
    }

    // Getter
    self.get = function () {
        return self;
    }
};
