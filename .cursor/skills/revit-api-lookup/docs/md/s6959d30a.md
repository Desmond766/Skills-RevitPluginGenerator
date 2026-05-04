---
kind: method
id: M:Autodesk.Revit.UI.PreviewControl.#ctor(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/1b4084c5-7adc-12fb-054b-ca639f4f3a07.htm
---
# Autodesk.Revit.UI.PreviewControl.#ctor Method

Constructs a preview control.

## Syntax (C#)
```csharp
public PreviewControl(
	Document document,
	ElementId viewId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **viewId** (`Autodesk.Revit.DB.ElementId`) - The view id want to browse in this control.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when dbDocument or viewId is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the given document is a linked document or the given viewId is invalid or the view is a schedule 
or other non-graphical view such as schedule views or the project browser view.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when there is an active preview control already.

