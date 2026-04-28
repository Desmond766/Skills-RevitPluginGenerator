---
kind: property
id: P:Autodesk.Revit.UI.SelectionUIOptions.SelectLinks
source: html/b08cf01a-6a3e-4833-8b73-ccf7803f977b.htm
---
# Autodesk.Revit.UI.SelectionUIOptions.SelectLinks Property

Indicates whether Revit and CAD link instances can be selected.

## Syntax (C#)
```csharp
public bool SelectLinks { get; set; }
```

## Remarks
When this setting is false, users cannot directly select link instances or elements within them in the
 canvas. This makes it easy for the user to avoid accidentally selecting and moving
 links. When this setting is true, users can select link instances.

