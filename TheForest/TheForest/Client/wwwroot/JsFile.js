window.displayTickerAlert1 = (symbol, price) => {
    alert(`${symbol}: $${price}!`);
    
};


window.displayRanger = () => {
    $('#ex20a').on('click', function (e) {
        $('#ex20a')
            .parent()
            .find(' >.card')
            .toggleClass()
            .find('input')
            .slider('relayout');
      /*  e.preventDefault();*/
    });
}



window.displayCarregaGrafico = (dataa) => {
   $(document).ready(function () {
        var options = {
            chart: {
                height: 320,
                type: 'pie',
            },
            labels: ['Team A', 'Team B', 'Team C', 'Team D', 'Team E'],
            series: [44, 55, 13, 43, 22],
            colors: ["#4680ff", "#9ccc65", "#00acc1", "#ffba57", "#ff5252"],
            legend: {
                show: true,
                position: 'bottom',
            },
            dataLabels: {
                enabled: true,
                dropShadow: {
                    enabled: false,
                }
            },
            responsive: [{
                breakpoint: 480,
                options: {
                    chart: {
                        width: 200
                    },
                    legend: {
                        position: 'bottom'
                    }
                }
            }]
        }
        var chart = new ApexCharts(
            document.querySelector("#pie-chart-1"),
            options
        );
        chart.render();
    });
};

window.displayCarregaGrafico2 = () => {
   // dat = JSON.parse(dataa)
    $(document).ready(function () {
        // [ besic-pie-chart ] Start
        Highcharts.chart('chart-highchart-pie1', {
            chart: {
                plotBackgroundColor: null,
                plotBorderWidth: null,
                plotShadow: false,
                type: 'pie'
            },
            colors: ['#4680ff', '#536dfe', '#ff5252', '#ffba57', '#00ACC1', '#11c15b'],
            title: {
                text: 'Browser market shares in '
            },
            tooltip: {
                pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
            },
            plotOptions: {
                pie: {
                    allowPointSelect: true,
                    cursor: 'pointer',
                    dataLabels: {
                        enabled: false
                    },
                    showInLegend: true
                }
            },
            series: [{
                name: 'Brands',
                colorByPoint: true,
                data: 
                    [{
                        name: 'Chrome',
                        y: 61.41,
                        sliced: true,
                        selected: true
                    }, {
                        name: 'Internet Explorer',
                        y: 11.84
                    }, {
                        name: 'Firefox',
                        y: 10.85
                    }, {
                        name: 'Edge',
                        y: 4.67
                    }, {
                        name: 'Safari',
                        y: 4.18
                    }, {
                        name: 'Other',
                        y: 7.05
                    }]
            }]


        });
        // [ basic-pie-chart ] end
    });

};