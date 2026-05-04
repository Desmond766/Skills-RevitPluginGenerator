---
kind: property
id: P:Autodesk.Revit.DB.Color.Red
zh: 着色、上色、染色、填色
source: html/23167ef4-6dea-f24d-3d9f-66a7e0204df2.htm
---
# Autodesk.Revit.DB.Color.Red Property

**中文**: 着色、上色、染色、填色

Get the red channel of the color. Setting a channel is obsolete in Autodesk Revit 2013. Please create a new color instead.

## Syntax (C#)
```csharp
public byte Red { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When getting the value: the color is invalid or uninitialized.

