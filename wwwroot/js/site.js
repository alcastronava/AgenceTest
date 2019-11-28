
function getRandomColor() {
    var letters = '0123456789ABCDEF'.split('');
    var color = '#';
    for (var i = 0; i < 6; i++) {
        color += letters[Math.floor(Math.random() * 16)];
    }
    return color;
}

function CreateCharts() {
    CreateChart();
    CreatePie();
}

function CreateChart() {
    $.ajax({
        url: '/Home/GetChartData',
        cache: false,
        type: "GET",
        success: function (chartData) {

            var mDataSets = [];
            var labelsArray = [];
            var costosArray = [];
            if (chartData.consultores.length > 0) {
                var consultor = chartData.consultores[0];
                $.each(consultor.list, function (index1, item) {
                    labelsArray.push(item.label);
                    costosArray.push(chartData.costo);
                });
            }

            $.each(chartData.consultores, function (index, consultor) {

                if (consultor.list.length > 0) {
                    var dataArray = [];
                    $.each(consultor.list, function (index1, item) {
                        dataArray.push(item.value);
                    });
                }
                var dataSet = {
                    label: consultor.nombre,
                    data: dataArray,
                    fill: false,
                    borderColor: getRandomColor()
                };

                mDataSets.push(dataSet);
            });

            var costo = {
                label: 'Costo Medio',
                data: costosArray,
                fill: false,
                borderColor: getRandomColor()
            };
            mDataSets.push(costo);

            var ctx = document.getElementById('ChartData').getContext('2d');
            var chart = new Chart(ctx, {
                type: 'line',
                data:
                {
                    labels: labelsArray,
                    datasets: mDataSets
                }
            });

        }
    });
}

function CreatePie() {
    $.ajax({
        url: '/Home/GetChartPie',
        cache: false,
        type: "GET",
        success: function (data) {

            if (data.length > 0) {
                var labelsArray = [];
                var dataArray = [];
                var colorArray = [];
                $.each(data, function (index, item) {
                    labelsArray.push(item.label);
                    dataArray.push(item.value);
                    colorArray.push(getRandomColor());
                });
                var ctx = document.getElementById('ChartPie').getContext('2d');
                chart = new Chart(ctx, {
                    type: 'pie',
                    data:
                    {
                        labels: labelsArray,
                        datasets: [{
                            backgroundColor: colorArray,
                            data: dataArray
                        }]
                    }
                });
            }

        }
    });
}
