---
kind: method
id: M:Autodesk.Revit.DB.SiteLocation.ConvertToProjectTime(System.DateTime)
source: html/fa540e18-7048-3186-dbcd-6f503caa18f1.htm
---
# Autodesk.Revit.DB.SiteLocation.ConvertToProjectTime Method

Converts local time or UTC time to project time.

## Syntax (C#)
```csharp
public DateTime ConvertToProjectTime(
	DateTime inputTime
)
```

## Parameters
- **inputTime** (`System.DateTime`) - The input local time or UTC time.

## Remarks
Daylight savings time is not considered during this conversion.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the inputTime's kind is neither Local nor Utc.

