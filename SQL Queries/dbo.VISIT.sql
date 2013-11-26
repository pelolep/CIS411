﻿CREATE TABLE [dbo].[VISIT] (
    [CLARION_ID]      INT          NOT NULL,
    [DATE]            DATE         NOT NULL,
    [TIME_IN]         TIME (7)     NOT NULL,
    [TIME_OUT]        TIME (7)     NULL,
    [TIME_DIFFERENCE] TIME (7)     NULL,
    [TERM]            INT NOT NULL,
    [SUBJECT]         VARCHAR (50) NOT NULL,
    [CATALOG]         VARCHAR (50) NOT NULL,
    [TUTOR_ID]        INT          NULL,
    [METHOD]          VARCHAR (50) NOT NULL,
    [SECTION]         VARCHAR (50) NOT NULL,
    CONSTRAINT [VISIT_PK] PRIMARY KEY CLUSTERED ([CLARION_ID] ASC, [DATE] ASC, [TIME_IN] ASC),
    CONSTRAINT [VISIT_TUTOR_ID_FK] FOREIGN KEY ([TUTOR_ID]) REFERENCES [dbo].[TUTOR] ([TUTOR_ID]),
    CONSTRAINT [VISIT_COURSE_FK] FOREIGN KEY ([TERM], [SUBJECT], [CATALOG], [SECTION]) REFERENCES [dbo].[COURSE] ([TERM], [SUBJECT], [CATALOG], [SECTION])
);

