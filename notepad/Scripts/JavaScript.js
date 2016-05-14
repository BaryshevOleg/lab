$(document).ready(function () {

    var List = [];
    var current  = -1;

    $("#InputBtn").click(function () {
        var name = $("#Name").val();
        if (name != "") {
            var exist = false;
            for (var i = 0; i < List.length; i++) {
                if (List[i].Name == name) {
                    exist = true;
                    return;
                }
            }
            if (!exist) {
                current = List.length - 1;
                List.push({
                    "Name": name,
                    "Text": ""
                });
                createbtn(name);
                $.post('/Save', { Name: name, Text: "" });
                Image();
            }
        }
    });

    $('#collectionbtn').on("click", ".btn", function () {
        current =  $(this).index();
        $(this).parent().children().removeClass('active');
        $(this).addClass('active');
        $('#Area').val(List[current].Text);
        Image();
    });

    function createbtn(name) {
        current = List.length - 1;
        $('#collectionbtn').children().removeClass('active');
        $("#collectionbtn").append('<button class="btn active" id="' + $("#collectionbtn").children().length + '">' + name + '</button>');
        $('#Area').val('');
        $('#Name').val('');
    }
    $("#SaveBtn").click(function () {
        var text = $("#Area").val();
        if (current != -1) {
            List[current].Text = text;
        }
        $.post('/Save',  List[current]);
    });
    function Image() {
        var xhr = new XMLHttpRequest();
        xhr.onreadystatechange = function () {
            if (this.readyState == 4 && this.status == 200) {
                var img = document.getElementById("img");
                var url = window.URL || window.webkitURL;
                img.src = url.createObjectURL(this.response);
            }
        }
        var formData = new FormData();
        if(current!=-1)
            formData.append('id', List[current].Name);
        else formData.append('id', 'Empty');
        xhr.open('POST', '/Imageload/', true)
        xhr.responseType = 'blob';
        xhr.send(formData);
    }
    Load();
    function Load()
    {
        $.ajax({
            url: '/Load',
            data: '',
            success: function (data) {
                if (data!= null && data != undefined)
                List = data;
            }
        }).then(function () {

                for (var i = 0; i < List.length; i++) {
                    createbtn(List[i].Name);
                }
                if (List.length > 0) {
                    var num = -1;
                    for (var i = 0; i < List.length; i++) {
                        if (List[i].Name == Name) {
                            num = i;
                            break;
                        }
                    }
                    if (num != -1) {
                        current = num;
                    } else current = -1;
                    if (current == -1 && List.length > 0) current = List.length - 1;
                    $('#collectionbtn').children().removeClass('active');
                    if(current!=-1){
                        $('.btn').eq(current).addClass('active');
                        $('#Area').val(List[current].Text);
                        Image();
                    }
                    $('#Name').val('');
                }
            });
    }
});
