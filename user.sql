-- Table: public.User

-- DROP TABLE public."User";

CREATE TABLE IF NOT EXISTS public."User"
(
    id integer,
    name text COLLATE pg_catalog."default",
    phone text COLLATE pg_catalog."default",
    remark text COLLATE pg_catalog."default"
)

TABLESPACE pg_default;

ALTER TABLE public."User"
    OWNER to postgres;