function openNavBar() {
    const container = document.querySelector(".container-content");
    container.classList.toggle("active");
}

/* Upload File */
$(document).ready(function() {
    $('#upload-file').change(function() {
        var filename = $(this).val();
        $('#file-upload-name').html(filename);
        if (filename != "") {
            setTimeout(function() {
                $('.upload-wrapper').addClass("uploaded");
            });
            setTimeout(function() {
                $('.upload-wrapper').removeClass("uploaded");
                $('.upload-wrapper').addClass("success");
            }, 1600);
        }
    });
});

/* owlCarousel */
$(document).ready(function() {

    $('.owl-carousel').owlCarousel({
        loop: true,
        margin: 2,
        autoplay: true,
        autoplayTimeout: 1000,
        nav: true,
        responsive: {
            0: {
                items: 1
            },
            600: {
                items: 1
            },
            1000: {
                items: 3
            }
        }
    });

    $('.owl-prev').click(function() {
        $active = $('.owl-item .item.show');
        $('.owl-item .item.show').removeClass('show');
        $('.owl-item .item').removeClass('next');
        $('.owl-item .item').removeClass('prev');
        $active.addClass('next');
        if ($active.is('.first')) {
            $('.owl-item .last').addClass('show');
            $('.first').addClass('next');
            $('.owl-item .last').parent().prev().children('.item').addClass('prev');
        } else {
            $active.parent().prev().children('.item').addClass('show');
            if ($active.parent().prev().children('.item').is('.first')) {
                $('.owl-item .last').addClass('prev');
            } else {
                $('.owl-item .show').parent().prev().children('.item').addClass('prev');
            }
        }
    });

    $('.owl-next').click(function() {
        $active = $('.owl-item .item.show');
        $('.owl-item .item.show').removeClass('show');
        $('.owl-item .item').removeClass('next');
        $('.owl-item .item').removeClass('prev');
        $active.addClass('prev');
        if ($active.is('.last')) {
            $('.owl-item .first').addClass('show');
            $('.owl-item .first').parent().next().children('.item').addClass('prev');
        } else {
            $active.parent().next().children('.item').addClass('show');
            if ($active.parent().next().children('.item').is('.last')) {
                $('.owl-item .first').addClass('next');
            } else {
                $('.owl-item .show').parent().next().children('.item').addClass('next');
            }
        }
    });

});

/* Gallery */

function filterImage(event) {
    const filterContainer = document.querySelector(".gallery-filter");
    const galleryItems = document.querySelectorAll(".gallery-item");

    if (event.target.classList.contains("filter-item")) {
        // deactivate existing active 'filter-item'
        filterContainer.querySelector(".active").classList.remove("active");
        // activate new 'filter-item'
        event.target.classList.add("active");
        const filterValue = event.target.getAttribute("data-filter");
        galleryItems.forEach((item) => {
            if (item.classList.contains(filterValue) || filterValue === 'all') {
                item.classList.remove("hide");
                item.classList.add("show");
            } else {
                item.classList.remove("show");
                item.classList.add("hide");
            }
        });
    }
}

/* download reports */

/* export Table To CSV */
function exportTableToCSV(filename) {
    var csv = [];
    var rows = document.querySelectorAll("table tr");
    for (var i = 0; i < rows.length; i++) {
        var row = [],
            cols = rows[i].querySelectorAll("td, th");
        for (var j = 0; j < cols.length; j++)
            row.push(cols[j].innerText);
        csv.push(row.join(","));
    }

    downloadCSV(csv.join("\n"), filename);
}

function downloadCSV(csv, filename) {
    var csvFile;
    var downloadLink;
    csvFile = new Blob([csv], { type: "text/csv" });
    downloadLink = document.createElement("a");
    downloadLink.download = filename;
    downloadLink.href = window.URL.createObjectURL(csvFile);
    downloadLink.style.display = "none";
    document.body.appendChild(downloadLink);

    downloadLink.click();
}

/* export Table To Excel */

function exportTableToExcel() {
    var tableId = document.getElementById('tableData').id;
    htmlTableToExcel(tableId, filename = '');
}

var htmlTableToExcel = function(tableId, fileName = '') {
    var downloadedFileName = 'excel_table_data';
    var TableDataType = 'application/vnd.ms-excel';
    var selectTable = document.getElementById(tableId);
    var htmlTable = selectTable.outerHTML.replace(/ /g, '%20');

    filename = filename ? filename + '.xls' : downloadedFileName + '.xls';
    var downloadingURL = document.createElement("a");
    document.body.appendChild(downloadingURL);

    if (navigator.msSaveOrOpenBlob) {
        var blob = new Blob(['\ufeff', htmlTable], {
            type: TableDataType
        });
        navigator.msSaveOrOpenBlob(blob, fileName);
    } else {

        downloadingURL.href = 'data:' + TableDataType + ', ' + htmlTable;
        downloadingURL.download = fileName;
        downloadingURL.click();
    }
}

/* print Table */

function printTable() {
    var el = document.getElementById("tableData");

    el.setAttribute('border', '5px');
    el.setAttribute('cellpadding', '5');
    el.setAttribute('color', 'green');
    newPrint = window.open("");
    newPrint.document.write(el.outerHTML);
    newPrint.print();
    newPrint.close();
}