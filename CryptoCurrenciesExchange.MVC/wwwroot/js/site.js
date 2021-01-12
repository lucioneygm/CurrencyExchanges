function loadExchangeRates() {

    $("#loadingRates").show();
    $("#ratesGrid").addClass("hide");

    if (window.table)
        window.table.destroy();

    axios.get('http://localhost:21735/api/ExchangeRates', {
        params: {
            trade: $('#trade').val(),
            to: $('#to').val()
        }
    })
        .then(function (response) {
            window.table = $('#rates').DataTable({
                data: response.data,
                columns: [
                    { data: 'exchange' },
                    { data: 'rate' },
                    { data: 'priceUSD' },
                    { data: 'requestTime' },
                    {
                        data: 'bestPrice',
                        render: function (data, type, row, meta) {
                            return data ?
                                '<span class="glyphicon glyphicon-ok bestPrice"></span>' :
                                '-';
                        }
                    }

                ]
            });

            $("#loadingRates").hide();
            $("#ratesGrid").removeClass("hide");
            console.log(response);
        });
}

function loadChart() {

    $("#loadingGraph").show();
    $("#graph").hide();

    axios.get('http://localhost:21735/api/Sentiment', {
        params: {
            trade: $('#trade').val(),
            to: $('#to').val()
        }
    })
        .then(function (response) {
            var result = response.data;

            if (!result || result.length == 0)
                return;

            var datasets = result.map(function (item) {
                return {
                    label: "Rates variation for: " + item.currency,
                    data: item.prices
                };
            });

            var ctx = document.getElementById('chart').getContext('2d');
            var chart = new Chart(ctx, {
                type: 'line',
                data: {
                    labels: result[0].timestamps,
                    datasets: datasets
                },
                options: {
                    responsive: false,
                    scales: {
                        yAxes: [{
                            ticks: {
                                beginAtZero: true
                            }
                        }]
                    }
                }
            });
        })
        .catch(function (error) {
            console.log(error);
        })
        .then(function () {
            $("#loadingGraph").hide();
            $("#graph").show();
        });
}

function loadSearch() {
    $("#ratesGrid").focus();
    loadExchangeRates();
    loadChart();
}

//$("#loadingGraph").hide();
//$("#loadingRates").hide();

$(document).ready(function () {    

    $('#trade').select2();
    $('#to').select2();

    $('#trade, #to').change(function () {
        if ($('#trade').val() && $('#to').val())
            loadSearch();
    });    
});
