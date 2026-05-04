---
kind: event
id: E:Autodesk.Revit.ApplicationServices.Application.LinkedResourceOpened
source: html/58045f61-5a60-aa9e-5360-afb39e51268e.htm
---
# Autodesk.Revit.ApplicationServices.Application.LinkedResourceOpened Event

Subscribe to the LinkedResourceOpened event to be notified immediately after Revit has finished opening a linked resource.

## Syntax (C#)
```csharp
public event EventHandler<LinkedResourceOpenedEventArgs> LinkedResourceOpened
```

## Remarks
This event is raised immediately after Revit has finished opening a linked resource.
 Only supports linked resources for following types : Revit; IFC; CAD(dwg, dxf, dgn, sat); Topography;
 It is raised even when a linked resource opening failed.
 The LinkedResourceOpened events would not raised if there are no update on linked CAD, IFC resources.
 Check the 'Status' field in event's argument to see whether the action itself was successful or not. Another LinkedResourceOpening event will be raised when Revit is just about to
 open a linked resource.

