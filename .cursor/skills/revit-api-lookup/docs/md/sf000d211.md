---
kind: type
id: T:Autodesk.Revit.DB.LineScaling
source: html/66e96d4a-6c06-0c50-bd03-f1db2ae83efb.htm
---
# Autodesk.Revit.DB.LineScaling

An enumerated type listing possible LineType scaling modes.

## Syntax (C#)
```csharp
public enum LineScaling
```

## Remarks
Whichever option is chosen, line type definitions are created so a dashed line always begins and ends with a dash.
 Using these options does change the default behavior of exported DWGs. Some lines expected to be dashed may appear solid or in a different scale.

