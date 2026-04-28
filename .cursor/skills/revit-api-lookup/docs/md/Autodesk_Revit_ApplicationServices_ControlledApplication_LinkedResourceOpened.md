---
kind: event
id: E:Autodesk.Revit.ApplicationServices.ControlledApplication.LinkedResourceOpened
source: html/4173dab8-f4da-ea8d-98c5-d6685349f159.htm
---
# Autodesk.Revit.ApplicationServices.ControlledApplication.LinkedResourceOpened Event

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

