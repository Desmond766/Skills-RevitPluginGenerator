---
kind: property
id: P:Autodesk.Revit.DB.Color.Blue
zh: 着色、上色、染色、填色
source: html/da86f079-e57f-450c-91c0-e3127f265e6f.htm
---
# Autodesk.Revit.DB.Color.Blue Property

**中文**: 着色、上色、染色、填色

Get the blue channel of the color. Setting a channel is obsolete in Autodesk Revit 2013. Please create a new color instead.

## Syntax (C#)
```csharp
public byte Blue { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When getting the value: the color is invalid or uninitialized.

