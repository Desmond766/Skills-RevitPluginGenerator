---
kind: method
id: M:Autodesk.Revit.DB.MEPAnalyticalConnection.GetFlow
source: html/4a39f08d-b4fe-5aad-17b1-a256e19a454c.htm
---
# Autodesk.Revit.DB.MEPAnalyticalConnection.GetFlow Method

Gets the flow value of this analytical connection.

## Syntax (C#)
```csharp
public double GetFlow()
```

## Returns
The flow value.

## Remarks
If the network flow is asynchronously calculated, this method would wait until the calculation is completed.
 This ensures the returned flow value is always up to date.

