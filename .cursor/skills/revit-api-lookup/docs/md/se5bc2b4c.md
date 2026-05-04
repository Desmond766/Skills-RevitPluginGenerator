---
kind: method
id: M:Autodesk.Revit.DB.SiteLocation.ConvertFromProjectTime(System.DateTime)
source: html/95392d0b-e94c-6464-36a5-8bc8c6b74295.htm
---
# Autodesk.Revit.DB.SiteLocation.ConvertFromProjectTime Method

Converts project time to UTC time.

## Syntax (C#)
```csharp
public DateTime ConvertFromProjectTime(
	DateTime projectTime
)
```

## Parameters
- **projectTime** (`System.DateTime`) - The project time.

## Remarks
Daylight savings time is not considered during this conversion.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the projectTime's kind is not Unspecified.

