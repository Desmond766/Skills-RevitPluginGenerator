---
kind: type
id: T:Autodesk.Revit.UI.IControllableDropHandler
source: html/ac732a43-fd23-0554-7fb8-9a082879b39d.htm
---
# Autodesk.Revit.UI.IControllableDropHandler

An interface to be executed when custom data is dragged and dropped onto the Revit user interface.
 This interface is different from IDropHandler in that it allows the handler to verify whether the drop event can be executed on the given view.

## Syntax (C#)
```csharp
public interface IControllableDropHandler : IDropHandler
```

## Remarks
Custom data is supported for drag and drop only during an invocation of the DoDragDrop method on Application.

