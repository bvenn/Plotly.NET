(**
// can't yet format YamlFrontmatter (["title: Parallel categories"; "category: Categorical Charts"; "categoryindex: 10"; "index: 1"], Some { StartLine = 2 StartColumn = 0 EndLine = 6 EndColumn = 8 }) to pynb markdown

# Parallel categories

[![Binder](https://plotly.net/img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath=8_0_parallel-categories.ipynb)&emsp;
[![Script](https://plotly.net/img/badge-script.svg)](https://plotly.net/8_0_parallel-categories.fsx)&emsp;
[![Notebook](https://plotly.net/img/badge-notebook.svg)](https://plotly.net/8_0_parallel-categories.ipynb)

*Summary:* This example shows how to create parallel categories plot in F#.

The parallel categories diagram (also known as parallel sets or alluvial diagram) is a visualization of multi-dimensional categorical data sets. Each variable in the data set is represented by a column of rectangles, where each rectangle corresponds to a discrete value taken on by that variable. The relative heights of the rectangles reflect the relative frequency of occurrence of the corresponding value.

Combinations of category rectangles across dimensions are connected by ribbons, where the height of the ribbon corresponds to the relative frequency of occurrence of the combination of categories in the data set.

*)
open Plotly.NET

let dims =
    [
        Dimensions.init(["Cat1";"Cat1";"Cat1";"Cat1";"Cat2";"Cat2";"Cat3"],Label="A")
        Dimensions.init([0;1;0;1;0;0;0],Label="B",TickText=["YES";"NO"])
    ]

let parcats =
    Chart.ParallelCategories(
        dims,
        Color=[0.;1.;0.;1.;0.;0.;0.],
        Colorscale = StyleParam.Colorscale.Blackbody
    )(* output: 
<div id="22fe96f9-6a09-4add-9296-a864f7adcd33" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_22fe96f96a094add9296a864f7adcd33 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"parcats","dimensions":[{"values":["Cat1","Cat1","Cat1","Cat1","Cat2","Cat2","Cat3"],"label":"A"},{"values":[0,1,0,1,0,0,0],"label":"B","ticktext":["YES","NO"]}],"color":[0.0,1.0,0.0,1.0,0.0,0.0,0.0],"line":{"colorscale":"Blackbody"}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('22fe96f9-6a09-4add-9296-a864f7adcd33', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_22fe96f96a094add9296a864f7adcd33();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_22fe96f96a094add9296a864f7adcd33();
            }
</script>
*)

