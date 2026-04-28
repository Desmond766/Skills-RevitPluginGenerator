---
kind: method
id: M:Autodesk.Revit.DB.ModelPathUtils.ConvertUserVisiblePathToModelPath(System.String)
source: html/0776a818-f032-a332-ac59-962953d8493a.htm
---
# Autodesk.Revit.DB.ModelPathUtils.ConvertUserVisiblePathToModelPath Method

Converts a user-visible path (string) to a ModelPath.

## Syntax (C#)
```csharp
public static ModelPath ConvertUserVisiblePathToModelPath(
	string strPath
)
```

## Parameters
- **strPath** (`System.String`) - The path in string form, like RSN://{HostNodeName}/school/project.rvt

## Returns
A ModelPath representing either a server or file path.

## Remarks
The path may be a server or file path.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

