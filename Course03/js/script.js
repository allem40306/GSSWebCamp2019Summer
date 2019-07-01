
var bookDataFromLocalStorage = [];

$(function(){
    loadBookData();
    var BookAddWindow = $("#bookadd_window");
    var BookAddWindowButton = $("#bookadd_window_button");
    BookAddWindowButton.click(function(){
        BookAddWindow.data("kendoWindow").open();
    });
    BookAddWindow.kendoWindow({
        width: "600px",
        title: "新增書籍",
        visible: false,
        actions: [
            "Close"
        ],
    }).data("kendoWindow").center();
    var data = [
        {text:"資料庫",value:"database"},
        {text:"網際網路",value:"internet"},
        {text:"應用系統整合",value:"system"},
        {text:"家庭保健",value:"home"},
        {text:"語言",value:"language"}
    ]
    $("#book_category").kendoDropDownList({
        dataTextField: "text",
        dataValueField: "value",
        dataSource: data,
        index: 0,
        change: onChange
    });
    $("#bought_datepicker").kendoDatePicker();
    $("#book_add").kendoButton({
        click: addBook
    });
    var grid = $("#book_grid").kendoGrid({
        dataSource: {
            data: bookDataFromLocalStorage,
            schema: {
                model: {
                    fields: {
                        BookId: {type:"int"},
                        BookName: { type: "string" },
                        BookCategory: { type: "string" },
                        BookAuthor: { type: "string" },
                        BookBoughtDate: { type: "string" }
                    }
                }
            },
            pageSize: 20,
        },
        toolbar: kendo.template("<div class='book-grid-toolbar'><input id='book_filter' class='book-grid-search' placeholder='搜尋書籍名稱......' type='text'></input></div>"),
        height: 550,
        sortable: true,
        pageable: {
            input: true,
            numeric: false
        },
        columns: [
            { field: "BookId", title: "書籍編號",width:"10%"},
            { field: "BookName", title: "書籍名稱", width: "50%" },
            { field: "BookCategory", title: "書籍種類", width: "10%" },
            { field: "BookAuthor", title: "作者", width: "15%" },
            { field: "BookBoughtDate", title: "購買日期", width: "15%" },
            { command: { text: "刪除", click: deleteBook }, title: " ", width: "120px" }
        ]
    });
    grid.find(".book-grid-search").on("keyup", function (e) {
        var dataSource = grid.data("kendoGrid").dataSource;
        var filtervalue = grid.find(".book-grid-search").val()
        e.preventDefault();
        dataSource.filter({
            field: "BookName",
            operator: "contains",
            value: filtervalue
        });
    });
})

function loadBookData(){
    bookDataFromLocalStorage = JSON.parse(localStorage.getItem("bookData"));
    if(bookDataFromLocalStorage == null){
        bookDataFromLocalStorage = bookData;
        localStorage.setItem("bookData",JSON.stringify(bookDataFromLocalStorage));
    }
}

function onChange(){
    $(".book-image").attr("src", 'image/' + $("#book_category").val() + '.jpg');
}

function addBook(){
    var validator = $("#bookadd_form").kendoValidator().data("kendoValidator");
    if(validator.validate()){
        console.log("ADD");
        var mx = 0;
        for(var i = 0; i != bookDataFromLocalStorage.length; ++i){
            if(mx < bookDataFromLocalStorage[i].BookId)
                mx = bookDataFromLocalStorage[i].BookId;
        }
        bookDataFromLocalStorage.push({BookId: mx + 1, BookName: $("#book_name").val(), BookCategory: $("#book_category").data("kendoDropDownList").text(), BookAuthor: $("#book_author").val(), BookBoughtDate: $("#bought_datepicker").val()});
        localStorage.setItem("bookData",JSON.stringify(bookDataFromLocalStorage));
        location.reload();
        alert("已新增書籍");
    }
    
}

function deleteBook(e){
    var answer = confirm("確定刪除?")
    if(!answer)return;
    var target = this.dataItem((e.target).closest("tr"));
    var targetId = target.BookId;
    for(var i = 0; i != bookDataFromLocalStorage.length; ++i){
        if(bookDataFromLocalStorage[i].BookId == targetId){
            bookDataFromLocalStorage.splice(i, 1);
            localStorage.setItem("bookData",JSON.stringify(bookDataFromLocalStorage));
            break;
        }
    }
    location.reload();
    alert("已刪除書籍");
}
