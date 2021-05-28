(**
// can't yet format YamlFrontmatter (["title: 3D Mesh plots"; "category: 3D Charts"; "categoryindex: 4"; "index: 4"], Some { StartLine = 2 StartColumn = 0 EndLine = 6 EndColumn = 8 }) to pynb markdown

# 3D Mesh plots

[![Binder](https://plotly.net/img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath=3_3_3d-mesh-plots.ipynb)&emsp;
[![Script](https://plotly.net/img/badge-script.svg)](https://plotly.net/3_3_3d-mesh-plots.fsx)&emsp;
[![Notebook](https://plotly.net/img/badge-notebook.svg)](https://plotly.net/3_3_3d-mesh-plots.ipynb)

*Summary:* This example shows how to create 3D-Mesh charts in F#.

let's first create some data for the purpose of creating example charts:

*)
open System
open Plotly.NET 


//---------------------- Generate linearly spaced vector ----------------------
let linspace (min,max,n) = 
    if n <= 2 then failwithf "n needs to be larger then 2"
    let bw = float (max - min) / (float n - 1.)
    Array.init n (fun i -> min + (bw * float i))
    //[|min ..bw ..max|]

//---------------------- Create example data ----------------------
let size = 100
let x = linspace(-2. * Math.PI, 2. * Math.PI, size)
let y = linspace(-2. * Math.PI, 2. * Math.PI, size)

let f x y = - (5. * x / (x**2. + y**2. + 1.) )

let z = 
    Array.init size (fun i -> 
        Array.init size (fun j -> 
            f x.[j] y.[i] 
        )
    )

let rnd = System.Random()
let a = Array.init 50 (fun _ -> rnd.NextDouble())
let b = Array.init 50 (fun _ -> rnd.NextDouble())
let c = Array.init 50 (fun _ -> rnd.NextDouble())


let mesh3d =
    Trace3d.initMesh3d 
        (fun mesh3d ->
            mesh3d?x <- a
            mesh3d?y <- b
            mesh3d?z <- c
            mesh3d?flatshading <- true
            mesh3d?contour <- Contours.initXyz(Show=true)
            mesh3d
            )
    |> GenericChart.ofTraceObject 
    (* output: 
<div id="f6a34b2b-fd35-4cb5-b08b-62d81268b2e8" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_f6a34b2bfd354cb5b08b62d81268b2e8 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"mesh3d","x":[0.9834913257432596,0.4736050914384448,0.5074237326660304,0.01988269948395095,0.8248020139638343,0.55355334587095,0.9955424228662357,0.6985707342152347,0.07981244478365986,0.45538093124301215,0.933547469290694,0.9460273114713036,0.3058139352620644,0.2091528439005617,0.1464697765868482,0.8091629747344009,0.07495610605690448,0.8985268221695567,0.9688933896687316,0.656105108398993,0.5392296926766772,0.9804015220051638,0.7960594044048616,0.08102873390588385,0.37562687898782404,0.5739131716889856,0.10783508192181358,0.24365662096238538,0.3674418289994084,0.22670644206307197,0.22284035255333426,0.7993502737019911,0.924072360584546,0.2501440421911627,0.5827351587744127,0.7019868445126278,0.1498537190024991,0.6285327750391014,0.875438841467462,0.5206121818724145,0.7478823609407443,0.4664617765073021,0.9657023595486313,0.07250103311264004,0.590343057918522,0.8198819145652847,0.11732897633562282,0.8595160780751687,0.5411273378604685,0.2846132057181621],"y":[0.27316480468640325,0.9928211197223613,0.8329902039063117,0.8177206049755777,0.6536367389623247,0.0030898037380957064,0.6775456870335833,0.4263949987601465,0.644255820496127,0.25088884227484876,0.4457182639491364,0.7518858019038503,0.33112890521582633,0.8531060027205879,0.23254057868967792,0.13419719558870288,0.021954950886757557,0.05566989307090169,0.6264176851261489,0.44448293207422035,0.6593092557319017,0.44642333101780307,0.023087980702094724,0.44828120779631714,0.9082227474582487,0.07276791616937514,0.01469916245653255,0.7235583712922216,0.4906856759873618,0.5557449644225393,0.4565841953533628,0.2483190038466449,0.7025292831019169,0.08282862328124634,0.9535416373766687,0.23001923283097298,0.9663600697956793,0.10635175560896833,0.596507303228838,0.5796453550363171,0.02444115747904459,0.7234587202423526,0.9842769545429745,0.6245499991926132,0.07489391792327814,0.995996559036894,0.13533287129147578,0.1125963568280434,0.8399604544229621,0.4561458623298192],"z":[0.7979269636785271,0.06165908326472113,0.23309839294901974,0.09664440578624811,0.6253039499862604,0.8267414736686002,0.9697331390202666,0.3847089961099946,0.9094978575173289,0.5808688227929495,0.9883906412815632,0.9539873157413618,0.9357093227727847,0.08851085607358761,0.794304646921486,0.19739926010249148,0.0493565188019334,0.24830028193457995,0.8995643653439191,0.0025213458587049252,0.16783712579302357,0.9156031952777892,0.45916258984206365,0.04677233008983188,0.4200417745951758,0.9358505354895492,0.46214637647482865,0.39853798150948155,0.37338728987303904,0.9122261884213547,0.9374350448778994,0.9021028056284891,0.8835979168692594,0.034539813657542606,0.7578180007440122,0.39492511208864167,0.01522061089762515,0.6058848773156688,0.457524673294986,0.12680016370806851,0.26028609381070644,0.5816510736856847,0.19685389809163933,0.015638480435888506,0.5912547137547539,0.07045384173768286,0.7877493974695677,0.8957660984693868,0.8302453522711272,0.8774946578207866],"flatshading":true,"contour":{"x":{"show":true},"y":{"show":true},"z":{"show":true}}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('f6a34b2b-fd35-4cb5-b08b-62d81268b2e8', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_f6a34b2bfd354cb5b08b62d81268b2e8();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_f6a34b2bfd354cb5b08b62d81268b2e8();
            }
</script>
*)

