---
kind: method
id: M:Autodesk.Revit.UI.UIApplication.OpenAndActivateDocument(System.String)
source: html/3b3d671d-47ec-2ed8-1818-a7c19d01884b.htm
---
# Autodesk.Revit.UI.UIApplication.OpenAndActivateDocument Method

Opens and activates a Revit document.

## Syntax (C#)
```csharp
public UIDocument OpenAndActivateDocument(
	string fileName
)
```

## Parameters
- **fileName** (`System.String`) - A full path to a revit file to be opened.
 The file can be either a Revit project, template, or family document.

## Returns
The opened document.

## Remarks
This method, if successful, changes the active document.
 It is not allowed to have an open transaction in the active document when calling this method.
 Additionally, this method may not be called from inside an event handler.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given 'fileName' is not a Revit file (a project, template, or family document).
- **Autodesk.Revit.Exceptions.ArgumentNullException** - If Nothing nullptr a null reference ( Nothing in Visual Basic) is passed as 'fileName'.
 -or-
 A non-optional argument was null
- **Autodesk.Revit.Exceptions.FileArgumentNotFoundException** - The file specified by 'fileName' cannot be found.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - If the active document is currently modifiable. If an API event handler is currently being executed.
- **Autodesk.Revit.Exceptions.RevitServerCommunicationException** - If there is any server internal error.

