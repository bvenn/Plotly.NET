(**
# Plotly.NET
 
[![Binder](https://plotly.net/img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath=index.ipynb)&emsp;
[![Script](https://plotly.net/img/badge-script.svg)](https://plotly.net/index.fsx)&emsp;
[![Notebook](https://plotly.net/img/badge-notebook.svg)](https://plotly.net/index.ipynb)

Plotly.NET provides functions for generating and rendering plotly.js charts in **.NET** programming languages 📈🚀. 

### Table of contents 

- [Installation](#Installation)
    - [For applications and libraries](#For-applications-and-libraries)
    - [For scripting](#For-scripting)
    - [For dotnet interactive notebooks](#For-dotnet-interactive-notebooks)
- [Overview](#Overview)
    - [Basics](#Basics)
        - [Initializing a chart](#Initializing-a-chart)
        - [Styling a chart](#Styling-a-chart)
        - [Displaying a chart](#Displaying-a-chart)
    - [Comparison: Usage in F# and C#](#Comparison-Usage-in-F-and-C)
        - [Functional pipeline style in F#](#Functional-pipeline-style-in-F)
        - [Fluent interface style in C#](#Fluent-interface-style-in-C)
        - [Declarative style in F# using the underlying `DynamicObj`](#Declarative-style-in-F-using-the-underlying)
        - [Declarative style in C# using the underlying `DynamicObj`](#Declarative-style-in-C-using-the-underlying)
- [Contributing and copyright](#Contributing-and-copyright)

# Installation

Plotly.NET will be available as 2.0.0 version of its predecessor FSharp.Plotly. The feature roadmap can be seen [here](https://github.com/plotly/Plotly.NET/issues/43). Contributions are very welcome!

Old packages up until version 1.2.2 can be accessed via the old package name *FSharp.Plotly* [here](https://www.nuget.org/packages/FSharp.Plotly/)

### For applications and libraries

A preview version of Plotly.NET 2.0.0 is available on nuget to plug into your favorite package manager.

You can find all available package versions on the [nuget page](https://www.nuget.org/packages/Plotly.NET/).

 - dotnet CLI

    ```shell
    dotnet add package Plotly.NET --version 2.0.0
    ```

 - paket CLI

    ```shell
    paket add Plotly.NET --version 2.0.0
    ```

 - package manager

    ```shell
    Install-Package Plotly.NET -Version 2.0.0
    ```

    Or add the package reference directly to your `.*proj` file:

    ```
    <PackageReference Include="Plotly.NET" Version="2.0.0" />
    ```

### For scripting

You can include the package via an inline package reference:

```
#r "nuget: Plotly.NET, 2.0.0"
```

### For dotnet interactive notebooks

You can use the same inline package reference as in script, but as an additional goodie, 
the interactive extensions for dotnet interactive have you covered for seamless chart rendering:

```
#r "nuget: Plotly.NET, 2.0.0"
#r "nuget: Plotly.NET.Interactive, 2.0.0"
```

_Note_: 

due to the currently fast development cycles of Dotnet Interactive, there might be increments in their versioning that renders the current version of Plotly.NET.Interactive incompatible (example [here](https://github.com/plotly/Plotly.NET/issues/67)).

If the interactive extension does not work, please file an issue and we will try to get it running again as soon as possible.

A possible fix for this is the inclusion of Dotnet.Interactive preview package sources. To use these, add the following lines before referencning Plotly.NET.Interactive:

```fsharp
#i "nuget:https://pkgs.dev.azure.com/dnceng/public/_packaging/dotnet5/nuget/v3/index.json"
#i "nuget:https://pkgs.dev.azure.com/dnceng/public/_packaging/dotnet-tools/nuget/v3/index.json"
```

# Overview

## Basics

The general design philosophy of Plotly.NET implements the following visualization flow:

- **initialize** a `GenericChart` object from the data you want to visualize by using the respective `Chart.*` function, optionally setting some specific style parameters
- further **style** the chart with fine-grained control, e.g. by setting axis titles, tick intervals, etc.
- **display** (in the browser or as cell result in a notebook) or save the chart 

### Initializing a chart

The `Chart` module contains a lot of functions named after the type of chart they will create, e.g. 
`Chart.Point` will create a point chart, `Chart.Scatter3d` wil create a 3D scatter chart, and so on.

The respective functions all contain specific arguments, but they all have in common that the first 
mandatory arguments are the data to visualize. 

Example: The first two arguments of the `Chart.Point` function are the x and y data. You can therefore initialize a point chart like this:


*)
open Plotly.NET
let xData = [0. .. 10.]
let yData = [0. .. 10.]
let myFirstChart = Chart.Point(xData,yData)
(**
### Styling a chart

Styling functions are generally the `Chart.with*` naming convention. The following styling example does:

 - set the chart title via `Chart.withTitle`
 - set the x axis title and removes the gridline from the axis via `Chart.withX_AxisStyle`
 - set the y axis title and removes the gridline from the axis via `Chart.withY_AxisStyle`


*)
let myFirstStyledChart =
    Chart.Point(xData,yData)
    |> Chart.withTitle "Hello world!"
    |> Chart.withX_AxisStyle ("xAxis", Showgrid=false)
    |> Chart.withY_AxisStyle ("yAxis", Showgrid=false)
(**
**Attention:** Styling functions mutate 😈 the input chart, therefore possibly affecting bindings to intermediary results. 
We recommend creating a single chart for each workflow to prevent unexpected results

### Displaying a chart in the browser

The `Chart.Show` function will open a browser window and render the input chart there. When working in a notebook context, after
[referencing Plotly.NET.Interactive](#For-dotnet-interactive-notebooks), the function is not necessary, just end the cell with the value of the chart.


*)
myFirstChart
|> Chart.Show
(**
Should render this chart in your brower:
<div id="4b5ca8f6-31de-4703-9c36-9e8c9e13742b" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_4b5ca8f631de47039c369e8c9e13742b = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatter","x":[0.0,1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[0.0,1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"mode":"markers","marker":{}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('4b5ca8f6-31de-4703-9c36-9e8c9e13742b', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_4b5ca8f631de47039c369e8c9e13742b();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_4b5ca8f631de47039c369e8c9e13742b();
            }
</script>

*)
myFirstStyledChart
|> Chart.Show
(**
And here is what happened after applying the styles from above:
<div id="76ae5e7d-ed02-41e5-b122-9f699ec6de4b" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_76ae5e7ded0241e5b1229f699ec6de4b = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"scatter","x":[0.0,1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"y":[0.0,1.0,2.0,3.0,4.0,5.0,6.0,7.0,8.0,9.0,10.0],"mode":"markers","marker":{}}];
            var layout = {"title":"Hello world!","xaxis":{"title":"xAxis","showgrid":false},"yaxis":{"title":"yAxis","showgrid":false}};
            var config = {};
            Plotly.newPlot('76ae5e7d-ed02-41e5-b122-9f699ec6de4b', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_76ae5e7ded0241e5b1229f699ec6de4b();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_76ae5e7ded0241e5b1229f699ec6de4b();
            }
</script>

### Displaying a chart in a notbook cell output

In a notebook context you usually have (at leat when running on a jupyter server like binder) no access to the browser on the machine where plotly runs on.
That's why you can render charts directly in the cell output. Just end the cell with the chart value:

*)
let xData' = [0. .. 10.]
let yData' = [0. .. 10.]
Chart.Point(xData',yData')
(**
Here is the styled chart:
*)
Chart.Point(xData,yData)
|> Chart.withTitle "Hello world!"
|> Chart.withX_AxisStyle ("xAxis", Showgrid=false)
|> Chart.withY_AxisStyle ("yAxis", Showgrid=false)
(**
## Comparison: Usage in F# and C#

One of the main design points of Plotly.NET it is to provide support for multiple flavors of chart generation. Here are 2 examples in different styles and languages that create an equivalent chart:
 
### Functional pipeline style in F#:

*)
[(1,5);(2,10)]
|> Chart.Point
|> Chart.withTraceName("Hello from F#",Showlegend=true)
|> Chart.withY_AxisStyle("xAxis",Showgrid= false, Showline=true)
|> Chart.withX_AxisStyle("yAxis",Showgrid= false, Showline=true)
(**
### Fluent interface style in C#:

```
static void Main(string[] args)
{
    double[] x = new double[] { 1, 2 };
    double[] y = new double[] { 5, 10 };
    GenericChart.GenericChart chart = Chart.Point(x: x, y: y);
    chart
        .WithTraceName("Hello from C#", true)
        .WithX_AxisStyle(title: "xAxis", Showgrid: false, Showline: true)
        .WithY_AxisStyle(title: "yAxis", Showgrid: false, Showline: true)
        .Show();
}
```

### Declarative style in F# using the underlying `DynamicObj`:

*)
let xAxis = 
    let tmp = Axis.LinearAxis()
    tmp?title <- "xAxis"
    tmp?showgrid <- false
    tmp?showline <- true    
    tmp

let yAxis =
    let tmp = Axis.LinearAxis()
    tmp?title <- "yAxis"
    tmp?showgrid <- false
    tmp?showline <- true    
    tmp

let layout =
    let tmp = Layout()
    tmp?xaxis <- xAxis
    tmp?yaxis <- yAxis
    tmp?showlegend <- true
    tmp

let trace = 
    let tmp = Trace("scatter")
    tmp?x <- [1;2]
    tmp?y <- [5;10]
    tmp?mode <- "markers"
    tmp?name <- "Hello from F#"
    tmp

GenericChart.ofTraceObject(trace)
|> GenericChart.setLayout layout
(**
### Declarative style in C# using the underlying `DynamicObj`:

```
static void Main(string[] args)
{
    double[] x = new double[] { 1, 2 };
    double[] y = new double[] { 5, 10 };

    Axis.LinearAxis xAxis = new Axis.LinearAxis();
    xAxis.SetValue("title", "xAxis");
    xAxis.SetValue("showgrid", false);
    xAxis.SetValue("showline", true);

    Axis.LinearAxis yAxis = new Axis.LinearAxis();
    yAxis.SetValue("title", "yAxis");
    yAxis.SetValue("showgrid", false);
    yAxis.SetValue("showline", true);

    Layout layout = new Layout();
    layout.SetValue("xaxis", xAxis);
    layout.SetValue("yaxis", yAxis);
    layout.SetValue("showlegend", true);

    Trace trace = new Trace("scatter");
    trace.SetValue("x", x);
    trace.SetValue("y", y);
    trace.SetValue("mode", "markers");
    trace.SetValue("name", "Hello from C#");

    GenericChart
        .ofTraceObject(trace)
        .WithLayout(layout)
        .Show();
}
```

# Contributing and copyright

The project is hosted on [GitHub][gh] where you can [report issues][issues], fork 
the project and submit pull requests. If you're adding a new public API, please also 
consider adding [samples][content] that can be turned into a documentation. You might
also want to read the [library design notes][readme] to understand how it works.

The library is available under Public Domain license, which allows modification and 
redistribution for both commercial and non-commercial purposes. For more information see the 
[License file][license] in the GitHub repository. 

  [content]: https://github.com/plotly/Plotly.NET/tree/master/docs/content
  [gh]: https://github.com/plotly/Plotly.NET
  [issues]: https://github.com/plotly/Plotly.NET/issues
  [readme]: https://github.com/plotly/Plotly.NET/blob/master/README.md
  [license]: https://github.com/plotly/Plotly.NET/blob/master/LICENSE.txt

*)

