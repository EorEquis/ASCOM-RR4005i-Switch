//*** CHECK THIS ProgID ***
var X = new ActiveXObject("ASCOM.RR4005i.Switch");
WScript.Echo("This is " + X.Name + ")");
// You may want to uncomment this...
// X.Connected = true;
X.SetupDialog();
