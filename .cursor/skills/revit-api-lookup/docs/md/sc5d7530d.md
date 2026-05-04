---
kind: type
id: T:Autodesk.Revit.DB.Structure.AnalyticalModelSelector
source: html/d286b023-8822-10ad-6702-53c86a6c9e70.htm
---
# Autodesk.Revit.DB.Structure.AnalyticalModelSelector

Defines a portion of an Analytical Model for an Element.

## Syntax (C#)
```csharp
public class AnalyticalModelSelector : IDisposable
```

## Remarks
This is used to identify the portion of an analytical model of interest to a client.
 To identify the portion of the analytical model, the client must identify
 the curve in question, by using one of the following:
 The specific curve within the analytical model. The index of the curve within the analytical model. 
If a specific part of that curve is of interest, the client needs to identify that by
 specifying one of the following:
 The start of the curve. The end of the curve. The entire curve. This is the default behavior, so this does not need specifying.

