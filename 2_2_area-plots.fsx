(**
// can't yet format YamlFrontmatter (["title: Area charts"; "category: Simple Charts"; "categoryindex: 3"; "index: 3"], Some { StartLine = 2 StartColumn = 0 EndLine = 6 EndColumn = 8 }) to pynb markdown

# Area charts

[![Binder](https://plotly.net/img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath=2_2_area-plots.ipynb)&emsp;
[![Script](https://plotly.net/img/badge-script.svg)](https://plotly.net/2_2_area-plots.fsx)&emsp;
[![Notebook](https://plotly.net/img/badge-notebook.svg)](https://plotly.net/2_2_area-plots.ipynb)

*Summary:* This example shows how to create area charts, area charts with splines, and stackes area charts in F#.

let's first create some data for the purpose of creating example charts:


*)
open Plotly.NET 
  
let x  = [1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10.; ]
let y  = [5.; 2.5; 5.; 7.5; 5.; 2.5; 7.5; 4.5; 5.5; 5.]
(**
An area chart or area graph displays graphically quantitive data. It is based on the line chart.
The area between axis and line are commonly emphasized with colors, textures and hatchings.

### Simple area chart

*)
let area1 = Chart.Area(x,y)(* output: 
<div id="bc4a4936-0f00-4bfd-9a2e-7a7111423227" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_bc4a49360f004bfd9a2e7a7111423227 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatter","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[5.0,2.5,5.0,7.5,5.0,2.5,7.5,4.5,5.5,5.0],"mode":"lines","fill":"tozeroy","line":{},"marker":{}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('bc4a4936-0f00-4bfd-9a2e-7a7111423227', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_bc4a49360f004bfd9a2e7a7111423227();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_bc4a49360f004bfd9a2e7a7111423227();
            }
</script>
*)
(**
### Area chart with a spline

*)
let area2 =
    Chart.SplineArea(x,y)(* output: 
<div id="4b59fcd1-ccec-437b-9dbf-49fdc45a0db4" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_4b59fcd1ccec437b9dbf49fdc45a0db4 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatter","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[5.0,2.5,5.0,7.5,5.0,2.5,7.5,4.5,5.5,5.0],"mode":"lines","fill":"tozeroy","line":{"shape":"spline"},"marker":{}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('4b59fcd1-ccec-437b-9dbf-49fdc45a0db4', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_4b59fcd1ccec437b9dbf49fdc45a0db4();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_4b59fcd1ccec437b9dbf49fdc45a0db4();
            }
</script>
*)
(**
### Stacked Area chart

*)
let stackedArea =
    [
        Chart.StackedArea(x,y)
        Chart.StackedArea(x,y |> Seq.rev)
    ]
    |> Chart.Combine(* output: 
<div id="5bfd6d0b-101d-41a2-ac0d-11e91901bd93" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_5bfd6d0b101d41a2ac0d11e91901bd93 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatter","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[5.0,2.5,5.0,7.5,5.0,2.5,7.5,4.5,5.5,5.0],"mode":"lines","line":{},"marker":{},"stackgroup":"static"},{"type":"scatter","x":[1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[5.0,5.5,4.5,7.5,2.5,5.0,7.5,5.0,2.5,5.0],"mode":"lines","line":{},"marker":{},"stackgroup":"static"}];
            var layout = {};
            var config = {};
            Plotly.newPlot('5bfd6d0b-101d-41a2-ac0d-11e91901bd93', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_5bfd6d0b101d41a2ac0d11e91901bd93();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_5bfd6d0b101d41a2ac0d11e91901bd93();
            }
</script>
*)

