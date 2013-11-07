CREATE TABLE [dbo].[VISIT] (
    [DATE]            DATE         NOT NULL,
    [TIME_IN]         TIME (7)     NOT NULL,
    [TIME_OUT]        TIME (7)     NULL,
    [TIME_DIFFERENCE] TIME (7)     NOT NULL,
    [CLARION_ID]      INT          NOT NULL,
    [TERM]            VARCHAR (50) NOT NULL,
    [SUBJECT]         VARCHAR (50) NOT NULL,
    [CATALOG]         VARCHAR (50) NOT NULL,
    [TUTOR_ID]        INT          NOT NULL,
    [METHOD]          VARCHAR (50) NOT NULL,
    [SECTION]         VARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([DATE] ASC, [TIME_IN] ASC),
    FOREIGN KEY ([TUTOR_ID]) REFERENCES [dbo].[TUTOR] ([TUTOR_ID])
);

