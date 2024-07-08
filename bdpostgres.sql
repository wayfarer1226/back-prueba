--
-- PostgreSQL database dump
--

-- Dumped from database version 16.3
-- Dumped by pg_dump version 16.3

-- Started on 2024-07-08 00:59:50

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- TOC entry 4 (class 2615 OID 2200)
-- Name: public; Type: SCHEMA; Schema: -; Owner: pg_database_owner
--

CREATE SCHEMA public;


ALTER SCHEMA public OWNER TO pg_database_owner;

--
-- TOC entry 4785 (class 0 OID 0)
-- Dependencies: 4
-- Name: SCHEMA public; Type: COMMENT; Schema: -; Owner: pg_database_owner
--

COMMENT ON SCHEMA public IS 'standard public schema';


SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 216 (class 1259 OID 16415)
-- Name: posts; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.posts (
    id uuid NOT NULL,
    nombre character varying(100),
    descripcion character varying(100)
);


ALTER TABLE public.posts OWNER TO postgres;

--
-- TOC entry 4779 (class 0 OID 16415)
-- Dependencies: 216
-- Data for Name: posts; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.posts (id, nombre, descripcion) FROM stdin;
4ab26a03-d2d0-4888-ac45-31fea357a2af	string	string
1c3983ad-3b98-431e-8b42-1ce3e4298401	xxxxxxxxxxxx	ccccccccccccc
a0a38815-0fcc-486c-a1f8-9eede3043a3f	nombre1	desc
a24425cc-d33f-4471-b684-9bef991ce23d	esetban	saaaa
a1164160-6a40-4cca-b543-313b6639258f	ssssss	aaaaaaaaaaaaa
\.


--
-- TOC entry 4635 (class 2606 OID 16419)
-- Name: posts posts_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.posts
    ADD CONSTRAINT posts_pkey PRIMARY KEY (id);


-- Completed on 2024-07-08 00:59:50

--
-- PostgreSQL database dump complete
--

