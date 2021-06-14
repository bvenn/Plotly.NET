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
<div id="9630a13f-a89a-4991-b7d8-0cd1a0c0b2e2" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_9630a13fa89a4991b7d80cd1a0c0b2e2 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"mesh3d","x":[0.7176524981472886,0.49668988608601033,0.07530419159461939,0.20690407008254158,0.8938711760071437,0.6751939974144073,0.7144367348935626,0.5174998564261477,0.4821365305605049,0.4821337342644733,0.8957903254291929,0.3828167018400583,0.39395316568853017,0.9274566825141463,0.9254823275494772,0.817206094422008,0.025816299964588275,0.29129290966842925,0.009380136620896,0.3273992824030105,0.9899952788790666,0.5226565355074855,0.7050520399143231,0.7382562773946003,0.1310827998123517,0.1438044403417988,0.7130144400117054,0.5899926524562727,0.07432119272384848,0.2503587781686144,0.2558418327271202,0.13020921364902016,0.08490118714277688,0.6615751933593187,0.6465880417481941,0.9673094227757815,0.157448834347282,0.14895599761463515,0.9907474424646923,0.49354333406944917,0.19997802665456108,0.23694412886954105,0.46688158738747315,0.24741696764129073,0.9979996555475517,0.6712508838024227,0.9660478350548296,0.48826799704146945,0.23177639592055996,0.774331710661916],"y":[0.8956162523923518,0.29840492051951817,0.5899791389657087,0.8324547111207874,0.450271171727344,0.19499596263980304,0.7916378461716873,0.33704791420001906,0.07582127027018987,0.750066735665345,0.9621795574027019,0.12444408243728991,0.4431786637022992,0.2317777523918905,0.22629190153735312,0.7655811117801727,0.2979155146972814,0.7323779723292114,0.28086864076595225,0.9581729047736958,0.659757260074726,0.8768603023499532,0.300545467203737,0.5158368025514468,0.12742125574844948,0.7530511500095255,0.05577494812001239,0.4576350722730323,0.7402566218470487,0.459831916009929,0.17775660528696915,0.22474644297023605,0.35821625653571276,0.29998948206193254,0.35474252577626264,0.957436912207602,0.5402300746833114,0.2524464760219895,0.21130402163197473,0.451592079108391,0.17567157660409416,0.820400920147263,0.07313472734444529,0.24068070679934728,0.5313637766667473,0.07553394421727115,0.7937654651672419,0.23510383499558263,0.0211250661039376,0.23241854376737892],"z":[0.3733353691051413,0.23366986272561824,0.2073993562755172,0.2736034911468641,0.11457445058718997,0.018755950042398623,0.9978594533157812,0.07414233641426188,0.705033455372338,0.6972200217178185,0.13922101451979066,0.33400277389865496,0.5967912923529703,0.6159893542602609,0.5723101303783759,0.7374331144324658,0.7662278259015771,0.14318918164036665,0.8770352266156278,0.2688549893297511,0.2253510370968613,0.04546903867529195,0.5210739506972367,0.8292765616575613,0.7825013281696016,0.8393563399274631,0.8037255750055078,0.059864760404389705,0.9844730258846995,0.051887311531178336,0.9592856848422837,0.8206711131244298,0.4365100061690947,0.5078380780796697,0.08649654690478767,0.944086742561351,0.017347086694718846,0.08461276538884861,0.1854150314747426,0.33598657573386403,0.9595774588918209,0.46608773826904953,0.5474130206496516,0.5140839999141563,0.3123710645886003,0.8416688027054392,0.22360962779429258,0.4571453730841844,0.6683705764209714,0.7939306622342815],"flatshading":true,"contour":{"x":{"show":true},"y":{"show":true},"z":{"show":true}}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('9630a13f-a89a-4991-b7d8-0cd1a0c0b2e2', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_9630a13fa89a4991b7d80cd1a0c0b2e2();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_9630a13fa89a4991b7d80cd1a0c0b2e2();
            }
</script>
*)

