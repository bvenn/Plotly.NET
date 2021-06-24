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
<div id="99df9310-5677-4b69-9bd0-3c92cdf703d3" style="width: 600px; height: 600px;"><!-- Plotly chart will be drawn inside this DIV --></div>
<script type="text/javascript">

            var renderPlotly_99df931056774b699bd03c92cdf703d3 = function() {
            var fsharpPlotlyRequire = requirejs.config({context:'fsharp-plotly',paths:{plotly:'https://cdn.plot.ly/plotly-latest.min'}}) || require;
            fsharpPlotlyRequire(['plotly'], function(Plotly) {

            var data = [{"type":"mesh3d","x":[0.35360971342474673,0.7106906169609588,0.8984181391533549,0.97240870118719,0.21322287675609014,0.11259184596715115,0.07751194624114406,0.8227363446833269,0.23635833674872217,0.575115262798553,0.8425017613184181,0.757591081670295,0.3103386798456026,0.06993925528132322,0.5061743499274246,0.47827718010092024,0.47395224937887503,0.6909036420709005,0.9182441718495656,0.11883485136499389,0.7321852192898212,0.09802079345007464,0.4928986055277747,0.059609621325325976,0.0900103468867067,0.22261772408272035,0.7422506873226961,0.6754318176188654,0.8570369933066131,0.3478630619812119,0.3349778155493447,0.5528026221100253,0.88039562100563,0.7408771401927234,0.09103205664597082,0.9519980894178143,0.5750716419774441,0.9197979722729874,0.8525560101738926,0.21665581977770468,0.2552954150621292,0.5335314383420774,0.3677837189136928,0.5394932481178517,0.6340356667684557,0.14422652877132713,0.37871066358811717,0.02970965347704927,0.38426399062586203,0.12212544126535088],"y":[0.747515439403949,0.005846214483420464,0.10100481850141883,0.30309176365988877,0.3488871154137361,0.2555889199746721,0.21779201143318416,0.8388085178280289,0.8823983543004833,0.9906051526733698,0.3703411586444551,0.40208012862227865,0.9656993513767139,0.8884952747675102,0.24013744724920832,0.2896991392083928,0.877195460664665,0.5694615396528792,0.9789071986353524,0.5541762605096103,0.9032055381234761,0.5541542771058876,0.8383476318970079,0.701588352071861,0.8635394363028647,0.1986537809477438,0.7302370745363818,0.953405357409923,0.42557395455687025,0.9457838181153796,0.8439070604946032,0.7125410338456468,0.2911678269930034,0.7349115520412621,0.6003476225772628,0.3291316010659242,0.4517978036086065,0.5773038573457412,0.3919900247789873,0.8354431366712987,0.7342060779846301,0.7362631241494152,0.03739961797250417,0.8619508575005228,0.8463146611332496,0.8532152864398506,0.5678320869653635,0.4792884441461826,0.29935580086864333,0.34433652756006294],"z":[0.26703106810666205,0.8092491239352381,0.05080245484169687,0.8300877301162517,0.21891990314187476,0.1933611622980615,0.1674985825864126,0.39941646642955786,0.4395523273570241,0.15023333446599232,0.5253518454382903,0.2643866540232611,0.41323456327115865,0.9366145361851037,0.14669809217876667,0.6578001247988083,0.11091230162927522,0.2307877993354517,0.2881476521902474,0.9110058461832841,0.8379013355997863,0.2998916033189239,0.17747151487389184,0.1434640619640537,0.8199701825249801,0.16694241397406087,0.5167546591333834,0.9763967743964851,0.8552736909386114,0.010324149863014068,0.6308216939823803,0.2509486303901992,0.6540495565412797,0.0812374269968073,0.6787527500087175,0.0346579365593651,0.66173857900395,0.46108009687675167,0.5159916488993874,0.4069864602792014,0.16163301847951161,0.05238133717904861,0.13775152998871706,0.24175669031299496,0.3100912912330084,0.46981942396136905,0.3230285608782566,0.10078508178740045,0.7152527653217562,0.1885145363344413],"flatshading":true,"contour":{"x":{"show":true},"y":{"show":true},"z":{"show":true}}}];
            var layout = {};
            var config = {};
            Plotly.newPlot('99df9310-5677-4b69-9bd0-3c92cdf703d3', data, layout, config);
});
            };
            if ((typeof(requirejs) !==  typeof(Function)) || (typeof(requirejs.config) !== typeof(Function))) {
                var script = document.createElement("script");
                script.setAttribute("src", "https://cdnjs.cloudflare.com/ajax/libs/require.js/2.3.6/require.min.js");
                script.onload = function(){
                    renderPlotly_99df931056774b699bd03c92cdf703d3();
                };
                document.getElementsByTagName("head")[0].appendChild(script);
            }
            else {
                renderPlotly_99df931056774b699bd03c92cdf703d3();
            }
</script>
*)

