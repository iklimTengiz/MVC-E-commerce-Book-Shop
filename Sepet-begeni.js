
   

        $(function () {
            $("#JvModal").dialog({
                autoOpen: false,
                show: {
                    effect: "blind",
                    duration: 1000
                },
                hide: {
                    effect: "explode",
                    duration: 1000
                }
            });

            $(".sepeteekle").on("click", function () {
                var pid = $(this).attr("data-pID");
                $.post("/Sepet/UrunEkle?ktpid=" + pid + "&adet=1", function (data) {
                    $("#JvModal").dialog("open");
                });


                return false;
            });

        });

   

        $(function () {
            $("#JvModal").dialog({
                autoOpen: false,
                show: {
                    effect: "blind",
                    duration: 1000
                },
                hide: {
                    effect: "explode",
                    duration: 1000
                }
            });

            $(".begeniekle").on("click", function () {
                var pid = $(this).attr("data-pID");
                $.post("/Begenilerim/begeniEkle?ktpid=" + pid + "&adet=1", function (data) {
                    $("#JvModal").dialog("open");
                });


                return false;
            });

        });
 



        function myFunction() {
            alert("Ürün Sepete eklenmiştir.");
        }
        function begeni() {
            alert("Ürünü daha sonra beğeni ekranında bulanilirsiniz.");
        }
