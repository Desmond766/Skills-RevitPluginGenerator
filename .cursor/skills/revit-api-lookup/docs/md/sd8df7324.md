---
kind: event
id: E:Autodesk.Revit.ApplicationServices.ControlledApplication.LinkedResourceOpening
source: html/7b027897-ea2a-a1ac-18b4-c2bd6717923d.htm
---
# Autodesk.Revit.ApplicationServices.ControlledApplication.LinkedResourceOpening Event

Subscribe to the LinkedResourceOpening event to be notified when Revit is just about to open a linked resource.

## Syntax (C#)
```csharp
public event EventHandler<LinkedResourceOpeningEventArgs> LinkedResourceOpening
```

## Remarks
This event is raised when Revit is just about to open a linked resource.
 Only supports linked resources for following types : Revit; IFC; CAD(dwg, dxf, dgn, sat);
 This event would not be raised if there are no update on linked CAD, IFC resources.
 Event is not cancellable. The linked resource cannot be modified, for it is not opened yet at the time of the event. Another LinkedResourceOpened event will be raised immediately after
 linked resource is opened.

