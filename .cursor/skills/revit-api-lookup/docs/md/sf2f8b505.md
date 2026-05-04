---
kind: method
id: M:Autodesk.Revit.DB.WorksharingTooltipInfo.GetRequesters
source: html/0a0ecf34-db77-997c-c9e3-e631c53fac78.htm
---
# Autodesk.Revit.DB.WorksharingTooltipInfo.GetRequesters Method

The ordered list of unique user names of users who have outstanding editing requests for
 the specified element.

## Syntax (C#)
```csharp
public IList<string> GetRequesters()
```

## Returns
The ordered list of unique user names.

## Remarks
The list is ordered by who placed the earliest request.
 If the list is empty it means that nobody is currently requesting the specified element.

